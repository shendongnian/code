    private ObservableCollection<dynamic> IEnumeratorToObservableCollection(IEnumerable source)
        {
            ObservableCollection<dynamic> SourceCollection = new ObservableCollection<dynamic>();
            IEnumerator enumItem = source.GetEnumerator();
            var gType = source.GetType();
            string collectionFullName = gType.FullName;
            Type[] genericTypes = gType.GetGenericArguments();
            string className = genericTypes[0].Name;
            string classFullName = genericTypes[0].FullName;
            string assName = (classFullName.Split('.'))[0];
            // Get the type contained in the name string
            Type type = Type.GetType(classFullName, true);
            // create an instance of that type
            object instance = Activator.CreateInstance(type);
            List<PropertyInfo> oProperty = instance.GetType().GetProperties().ToList();
            while (enumItem.MoveNext())
            {
                Object instanceInner = Activator.CreateInstance(type);
                var x = enumItem.Current;
                foreach (var item in oProperty)
                {
                    if (x.GetType().GetProperty(item.Name) != null)
                    {
                        var propertyValue = x.GetType().GetProperty(item.Name).GetValue(x, null);
                        if (propertyValue != null)
                        {
                            PropertyInfo prop = type.GetProperty(item.Name);
                            prop.SetValue(instanceInner, propertyValue, null);
                        }
                    }
                }
                SourceCollection.Add(instanceInner);
            }
            
            return SourceCollection;
        }
