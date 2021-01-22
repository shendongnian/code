    using System.ComponentModel;
    using System.Linq;
    /// <summary>
    /// Check if every property respons to INotifyPropertyChanged with the correct property name
    /// </summary>
    public static class NotificationTester
        {
            public static object GetPropertyValue(object src, string propName)
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }
    
            public static bool Verify<T>(T inputClass) where T : INotifyPropertyChanged
            {
                var properties = inputClass.GetType().GetProperties().Where(x => x.CanWrite);
                var index = 0;
    
                var matchedName = 0;
                inputClass.PropertyChanged += (o, e) =>
                {
                    if (properties.ElementAt(index).Name == e.PropertyName)
                    {
                        matchedName++;
                    }
    
                    index++;
                };
    
                foreach (var item in properties)
                { 
                    // use setter of property
                    item.SetValue(inputClass, GetPropertyValue(inputClass, item.Name));
                }
    
                return matchedName == properties.Count();
            }
        }
