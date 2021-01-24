    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Internal;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    
    namespace EntityFrameworkCore.CustomMigration
    {
        public static class CustomModelBuilder
        {
            public static bool IsSignedInteger(this Type type)
               => type == typeof(int)
                  || type == typeof(long)
                  || type == typeof(short)
                  || type == typeof(sbyte);
    
            public static void Seed<T>(this ModelBuilder modelBuilder, IEnumerable<T> data) where T : class
            {
                var entnty = modelBuilder.Entity<T>();
    
                var pk = entnty.Metadata
                    .GetProperties()
                    .FirstOrDefault(property => 
                        property.RequiresValueGenerator() 
                        && property.IsPrimaryKey()
                        && property.ClrType.IsSignedInteger()
                        && property.ClrType.IsDefaultValue(0)
                    );
                if (pk != null)
                {
                    entnty.Property(pk.Name).ValueGeneratedNever();
                    entnty.HasData(data);
                    entnty.Property(pk.Name).UseSqlServerIdentityColumn();
                }
                else
                {
                    entnty.HasData(data);
                }          
            }
        }
    }
