            MyType myType = new MyType();
            if (IsOfNullableType(myType.MyId))
            {
                Type t = typeof(MyType).GetProperty(nameof(MyType.MyId)).PropertyType;
                var props = t.GetProperties();
                Console.WriteLine(props[1].PropertyType.FullName);
                // Prints "System.Int32"
            }
