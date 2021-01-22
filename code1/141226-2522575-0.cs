    public static class SilverlightExtensions
    {
        public static T Clone<T>(T source)
        {
            T cloned = (T) Activator.CreateInstance(source.GetType());
 
            foreach (PropertyInfo curPropInfo in source.GetType().GetProperties())
            {
                if (curPropInfo.GetGetMethod() != null
                    && (curPropInfo.GetSetMethod() != null))
                {
                    // Handle Non-indexer properties
                    if (curPropInfo.Name != "Item")
                    {
                        // get property from source
                        object getValue = curPropInfo.GetGetMethod().Invoke(source, new object[] {});
 
                        // clone if needed
                        if (getValue != null && getValue is DependencyObject)
                            getValue = Clone((DependencyObject) getValue);
 
                        // set property on cloned
                        if (getValue != null)
                        curPropInfo.GetSetMethod().Invoke(cloned, new object[] {getValue});
                    }
                        // handle indexer
                    else
                    {
                        // get count for indexer
                        int numberofItemInColleciton =
                            (int)
                            curPropInfo.ReflectedType.GetProperty("Count").GetGetMethod().Invoke(source, new object[] {});
 
                        // run on indexer
                        for (int i = 0; i < numberofItemInColleciton; i++)
                        {
                            // get item through Indexer
                            object getValue = curPropInfo.GetGetMethod().Invoke(source, new object[] {i});
 
                            // clone if needed
                            if (getValue != null && getValue is DependencyObject)
                                getValue = Clone((DependencyObject) getValue);
                            // add item to collection
                            curPropInfo.ReflectedType.GetMethod("Add").Invoke(cloned, new object[] {getValue});
                        }
                    }
                }
            }
 
            return cloned;
        }
    }
