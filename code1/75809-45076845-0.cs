    public static class TraversalHelper
    {
        public static void TraverseAndExecute(object node)
        {
            TraverseAndExecute(node, 0);
        }
        public static void TraverseAndExecute(object node, int level)
        {
            foreach (var property in node.GetType().GetProperties())
            {
                var propertyValue = node.GetType().GetProperty(property.Name).GetGetMethod().Invoke(node, null); // Get the value of the property
                if (null != propertyValue)
                {
                    Console.WriteLine("Level=" + level + " :  " + property.Name + " :: " + propertyValue.GetType().Name); // For debugging
                    if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(ObservableCollection<>)) // Check if we are dealing with an observable collection
                    {
                        //var dummyvar = propertyValue.GetType().GetMethods();   // This was just used to see which methods I could find on the Collection
                        Int32 propertyValueCount = (Int32)propertyValue.GetType().GetMethod("get_Count").Invoke(propertyValue, null); // How many objects in the collection
                        level++;
                        for (int i = 0; i < propertyValueCount; i++) // Loop over all objects in the Collection
                        {
                            object properyValueObject = (object)propertyValue.GetType().GetMethod("get_Item").Invoke(propertyValue, new object[] { i }); // Get the specified object out of the Collection
                            TraverseAndExecute(properyValueObject, level); // Recursive call in case this object is a Collection too
                        }
                    }
                }
            }
        }
    }
