UPDATE Channels SET MessageIdCounter = $incrementedValue
WHERE ChannelId = $channelId AND MessageIdCounter = $originalValue;
The database server will return the number of changes. If no changes have been made, the `MessageIdCounter` must have changed in the meantime. Then we have to run the operation again.
## Implementation ##
Entities:
public class Channel
{
    public long ChannelId { get; set; }
    public long MessageIdCounter { get; set; }
    public IEnumerable<Message> Messages { get; set; }
}
public class Message
{
    public long MessageId { get; set; }
    public byte[] Content { get; set; }
    public long ChannelId { get; set; }
    public Channel Channel { get; set; }
}
Database context:
public class DatabaseContext : DbContext
{
    public DbSet<Channel> Channels { get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        var channel = builder.Entity<Channel>();
        channel.HasKey(c => c.ChannelId);
        channel.Property(c => c.MessageIdCounter).IsConcurrencyToken();
        var message = builder.Entity<Message>();
        message.HasKey(m => new { m.ChannelId, m.MessageId });
        message.HasOne(m => m.Channel).WithMany(c => c.Messages).HasForeignKey(m => m.ChannelId);
    }
}
Utility method:
/// <summary>
/// Call this method to retrieve a MessageId for inserting a Message.
/// </summary>
public long GetNextMessageId(long channelId)
{
    using (DatabaseContext ctx = new DatabaseContext())
    {
        bool saved = false;
        Channel channel = ctx.Channels.Single(c => c.ChannelId == channelId);
        long messageId = ++channel.MessageIdCounter;
        do
        {
            try
            {
                ctx.SaveChanges();
                saved = true;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();    
                var proposedValues = entry.CurrentValues;
                var databaseValues = entry.GetDatabaseValues();
                const string name = nameof(Channel.MessageIdCounter);
                proposedValues[name] = messageId = (long)databaseValues[name] + 1;
                entry.OriginalValues.SetValues(databaseValues);
            }
        } while (!saved);
        return messageId;
    }
}
> For successfully using EF Core's concurrency tokens I had to set MySQL's transaction isolation at least to `READ COMMITTED`.
## Summary ##
It is possible to implement an incremental id per foreign key with EF Core.
This solution is not perfect because it needs two transactions for one insert and is therefore slower than an auto-increment row. Furthermore it's possible that `MessageId`s are skipped when the application crashes while inserting a Message.
