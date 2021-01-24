c#
namespace Microsoft.EntityFrameworkCore
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Reflection;
    public static class ModelBuilderExtensions
    {
        public static void SetDefaultValuesTableName(this ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes().Where(x => x.ClrType.GetCustomAttribute(typeof(TableAttribute)) != null))
            {
                var entityClass = entity.ClrType;
                foreach (var property in entityClass.GetProperties().Where(p => (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(Guid)) && p.CustomAttributes.Any(a => a.AttributeType == typeof(DatabaseGeneratedAttribute))))
                {
                    var defaultValueSql = "GetDate()";
                    if (property.PropertyType == typeof(Guid))
                    {
                        defaultValueSql = "newsequentialid()";
                    }
                    modelBuilder.Entity(entityClass).Property(property.Name).HasDefaultValueSql(defaultValueSql);
                }
            }
        }
    }
}
2. Modify your OnModelCreating method
csharp
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.SetDefaultValuesTableName();
    }
3. Profit
[Source][1]
  [1]: https://gist.github.com/DiomedesDominguez/797711e093fd15eff4265ae9d5dc27b9
