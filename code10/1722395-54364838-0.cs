    using AutoMapper;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    namespace YourNamespaceHere
    {
        public static class AutoMapperExtensions
        {
            public static IMappingExpression<TSource, TDestination> LimitStrings<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
            {
                var sourceType = typeof(TSource);
                var destinationType = typeof(TDestination);
                var existingMaps = Mapper.Configuration.GetAllTypeMaps().First(b => b.SourceType == sourceType && b.DestinationType == destinationType);
                var propertyMaps = existingMaps.PropertyMaps.Where(map => !map.Ignored && ((PropertyInfo)map.SourceMember).PropertyType == typeof(string));
                foreach (var propertyMap in propertyMaps)
                {
                    var attr = propertyMap.DestinationMember.GetCustomAttribute<MaxLengthAttribute>();
                    if (attr != null)
                    {
                        expression.ForMember(propertyMap.DestinationMember.Name,
                            opt => opt.ConvertUsing(new StringLimiter(attr.Length), propertyMap.SourceMember.Name));
                    }
                }
                return expression;
            }
        }
        public class StringLimiter : IValueConverter<string, string>
        {
            private readonly int length;
            private readonly PropertyInfo propertyMapSourceMember;
            public StringLimiter(int length)
            {
                this.length = length;
                propertyMapSourceMember = propertyMapSourceMember ?? throw new ArgumentNullException(nameof(propertyMapSourceMember));
            }
            public string Convert(string sourceMember, ResolutionContext context)
            {
                var sourceValue = (string)propertyMapSourceMember.GetValue(sourceMember);
                return new string(sourceValue.Take(length).ToArray());
            }
        }
    }
