            fou test_fou = new fou();
            Type type = FB.GetType();
            type = type.BaseType;
            UpdateForType(type, FB, test_fou);
            return test_fou;
        }
        private static void UpdateForType(Type type, foubar source, fou destination)
        {
            FieldInfo[] myObjectFields = type.GetFields(
                BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo fi in myObjectFields)
            {
                fi.SetValue(destination, fi.GetValue(source));
            }
        }
