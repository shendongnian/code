           public static Foo Create(int id, string property, string value)
           {
               Foo foo = new Foo() { Id = id };
                   
               PropertyInfo propertyInfo = foo.GetType().GetProperty(property);
               propertyInfo.SetValue(foo, Convert.ChangeType(value, propertyInfo.PropertyType), null);
               return foo;
           }
