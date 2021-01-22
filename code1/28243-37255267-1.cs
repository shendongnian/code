        public class Entity
        {
            public string Name { get; set; }
            public byte? Value { get; set; }
        }
        static void SetNullableWithReflection()
        {
            // Build array as requested
            Dictionary<string, string> props = new Dictionary<string, string>();
            props.Add("Name", "First name");
            props.Add("Value", "1");
            // The entity
            Entity entity = new Entity();
            // For each property to assign with a value
            foreach (var item in props)
                entity.SetProperty(item.Key, item.Value);
            // Check result
            Debug.Assert(entity.Name == "First name");
            Debug.Assert(entity.Value == 1);
        }
