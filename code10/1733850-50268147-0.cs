        public static void DisposeAllMembersWithReflection(object target)
        {
            if (target == null) return;
            // get all fields,  you can change it to GetProperties() or GetMembers()
            var fields = target.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            // get all fields that implement IDisposable
            var disposables = fields.Where(x => x.FieldType.GetInterfaces().Contains(typeof(IDisposable)));
    
            foreach (var disposableField in disposables)
            {
                var value = (IDisposable)disposableField.GetValue(target);
                if (value != null)
                    value.Dispose();
            }
        }
