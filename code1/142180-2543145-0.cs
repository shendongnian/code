            object arg = ...;
            MethodInfo method = typeof(YourType)
                .GetMethod("Test", BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(arg.GetType());
            method.Invoke(this, new object[] { arg });
