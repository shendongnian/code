            Type objectType = obj.GetType();
            Type interfaceType = typeof(IExample);
            if (interfaceType.IsAssignableFrom(objectType))
            {
                //...
            }
