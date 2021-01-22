    public void CopyTo(object source, object destination)
            {
                var sourceProperties = source.GetType().GetProperties()
                       .Where(p => p.CanRead);
                var destinationProperties = destination.GetType()
                    .GetProperties().Where(p => p.CanWrite);
                foreach (var property in sourceProperties)
                {
                    var targets = (from d in destinationProperties
                                   where d.Name == property.Name
                                   select d).ToList();
                    if (targets.Count == 0)
                        continue;
                    var activeProperty = targets[0];
                    object value = property.GetValue(source, null);
                    activeProperty.SetValue(destination, value, null);
                }
            }
