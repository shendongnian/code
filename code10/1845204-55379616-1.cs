csharp
public class UserEntity
{
    public int Id { get; set; }
    [Encrypted]
    public string Username { get; set; }
    [Encrypted]
    public string Password { get; set; }
    public int Age { get; set; }
}
public class DatabaseContext : DbContext
{
    // Get key and IV from a Base64String or any other ways.
    // You can generate a key and IV using "AesProvider.GenerateKey()"
    private readonly byte[] _encryptionKey = ...; 
    private readonly byte[] _encryptionIV = ...;
    private readonly IEncryptionProvider _provider;
    public DbSet<UserEntity> Users { get; set; }
    public DatabaseContext(DbContextOptions options)
        : base(options)
    {
        this._provider = new AesProvider(this._encryptionKey, this._encryptionIV);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseEncryption(this._provider);
    }
}
Results on saving:
![encryption](https://i.imgur.com/wFNhFyX.png)
Hope it helps.
