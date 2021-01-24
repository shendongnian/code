       public static TResult HydrateEntityToVM<T, TResult>(T inputValue, TResult resultValue) where T : class 
        {
            if (inputValue == null || resultValue == null)
                return default(TResult);
            var idValue = inputValue.GetType().GetProperty("Id").GetValue(inputValue);
            var nameValue = inputValue.GetType().GetProperty("Name").GetValue(inputValue);
            object instance;
            if (resultValue == null)
            {
                var ctor = resultValue.GetType().GetConstructor(Type.EmptyTypes);
                instance = ctor.Invoke(new object[] {});
            }
            else
            {
                instance = resultValue;
            }
            var idProp = instance.GetType().GetProperty("Id");
            if (idProp != null)
            {
                if (idProp.CanWrite)
                    idProp.SetValue(instance, idValue);
            }
            var nameProp = instance.GetType().GetProperty("Name");
            if (nameProp != null)
            {
                if (nameProp.CanWrite)
                    nameProp.SetValue(instance, nameValue);
            }
                
            return (TResult) instance;
        }
