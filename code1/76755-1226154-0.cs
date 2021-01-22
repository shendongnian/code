         public static PropertyInfo PropertyOf<T>(Expression<Func<T>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            PropertyInfo pi = body.Member as PropertyInfo;
            if (pi != null)
            {
                return pi;
            }
            else throw new ArgumentException("Lambda must be a Property.");
        } 
          [TestMethod()]
        public void MethodofPropertyOfTest<T>()
        {
            string foo = "Jamming";
            MethodInfo method1 = ReflectionHelper.Methodof(() => default(string).ToString());
            PropertyInfo prop = ReflectionHelper.PropertyOf(() => default(string).Length);
            Assert.AreEqual(method1.Invoke(foo, null), "Jamming");
            Assert.AreEqual(prop.GetGetMethod().Invoke(foo, null), foo.Length);
        }
