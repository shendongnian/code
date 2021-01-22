     var properties = typeof(TestSubject).GetProperties(BindingFlags.Instance | BindingFlags.Public)
            .Where(ø => ø.CanRead && ø.CanWrite)
            .Where(ø => ø.PropertyType == typeof(string))
            .Where(ø => ø.GetGetMethod(true).IsPublic)
            .Where(ø => ø.GetSetMethod(true).IsPublic);
