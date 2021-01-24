    public class Mapper
    {
        public static TRes Convert<TIn, TRes>(TIn obj)
        {
            TRes targetInstance = Activator.CreateInstance<TRes>();
            var sourceTypePropertyInfos = obj.GetType().GetProperties();
            var targetTypePropertyInfos = targetInstance.GetType().GetProperties();
            foreach (var sourceTypePropertyInfo in sourceTypePropertyInfos)
            {
                foreach (var targetTypePropertyInfo in targetTypePropertyInfos)
                {
                    if (sourceTypePropertyInfo.Name == targetTypePropertyInfo.Name)
                    {
                        if (sourceTypePropertyInfo.PropertyType == targetTypePropertyInfo.PropertyType)
                        {
                            targetTypePropertyInfo.SetValue(targetInstance, sourceTypePropertyInfo.GetValue(obj));
                        }
                        else
                        {
                            var sourcePropertyValue = sourceTypePropertyInfo.GetValue(obj);
                            var methodInfo = typeof(Mapper).GetMethod(nameof(Mapper.Convert));
                            var genericMethodInfo = methodInfo.MakeGenericMethod(sourceTypePropertyInfo.PropertyType, targetTypePropertyInfo.PropertyType);
                            var targetValue = genericMethodInfo.Invoke(new Mapper(), new[] { sourcePropertyValue });
                            targetTypePropertyInfo.SetValue(targetInstance, targetValue);
                        }
                    }
                }
            }
            return targetInstance;
        }
    }
