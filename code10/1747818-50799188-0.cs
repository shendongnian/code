            var instance = Activator.CreateInstance(implementation);
            var results = this.GetType()
                .GetMethod("CheckForMessages", BindingFlags.NonPublic | BindingFlags.Instance)
                .MakeGenericMethod(interfaceUsesType)
                .Invoke(this, null) as object[];
            
            if(results.Count() > 0)
                instance.GetType().GetMethod("DoThis").Invoke(instance, new object[] {results});
