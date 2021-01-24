migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "SomeTable",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
To this:
migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "SomeTable",
                nullable: false)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn);
The migration script will then spit out the correct SQL with `DEFAULT CURRENT_TIMESTAMP` for `TIMESTAMP`. If you remove the `[Column(TypeName = "TIMESTAMP")]` attribute, it will use a `datetime(6)` column and spit out `DEFAULT CURRENT_TIMESTAMP(6)`.
**EDIT:**
I've come up with a workaround that correctly implements Created Time (updated by the database only on INSERT) and Updated time (updated by the database only on INSERT and UPDATE):
builder.Entity<SomeEntity>.Property(d => d.CreatedTime).ValueGeneratedOnAdd();
builder.Entity<SomeEntity>.Property(d => d.UpdatedTime).ValueGeneratedOnAddOrUpdate();
builder.Entity<SomeEntity>.Property(d => d.CreatedTime).Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
builder.Entity<SomeEntity>.Property(d => d.CreatedTime).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
builder.Entity<SomeEntity>.Property(d => d.UpdatedTime).Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
builder.Entity<SomeEntity>.Property(d => d.UpdatedTime).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
This produces a perfect initial migration (where `migrationBuilder.CreateTable` is used), and generates the expected SQL:
`created_time` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
`updated_time` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6) ON UPDATE CURRENT_TIMESTAMP(6),
This *should* also work on migrations that update existing tables, but do make sure that `defaultValue` is always null.
The `PropertySaveBehavior` lines prevent EF from ever trying to overwrite the Created time with a default value. It effectively makes the Created and Updated columns read only from EF's point of view, allowing the database to do all of the work.
You can even extract this into an interface and extension method:
public interface ITimestampedEntity
    {
        DateTime CreatedTime { get; set; }
        DateTime UpdatedTime { get; set; }
    }
public static EntityTypeBuilder<TEntity> UseTimestampedProperty<TEntity>(this EntityTypeBuilder<TEntity> entity) where TEntity : class, ITimestampedEntity
{
    entity.Property(d => d.CreatedTime).ValueGeneratedOnAdd();
    entity.Property(d => d.UpdatedTime).ValueGeneratedOnAddOrUpdate();
    entity.Property(d => d.CreatedTime).Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
    entity.Property(d => d.CreatedTime).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    entity.Property(d => d.UpdatedTime).Metadata.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
    entity.Property(d => d.UpdatedTime).Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
    return entity;
}
Then implement the interface on all of your timestamped entities. This allows you to set up the Entity from within `OnModelCreating()` like so:
builder.Entity<SomeTimestampedEntity>().UseTimestampedProperty();
This will also work with `DateTimeOffset` after [issue 799](https://github.com/PomeloFoundation/Pomelo.EntityFrameworkCore.MySql/issues/799) is fixed.
