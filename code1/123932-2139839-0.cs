        public static void SutPropertyHasAttribute<TSut, TProperty>(this Fixture fixture, Expression<Func<TSut, TProperty>> propertyExpression, Type attributeType)
        {
            var pi = (PropertyInfo)((MemberExpression)propertyExpression.Body).Member;
            var count = pi.GetCustomAttributes(attributeType, true).Count();
            Assert.AreEqual(1, count);
        }
        public static void SutHasAttribute<TSut>(this Fixture fixture, Type attributeType)
        {
            var type = typeof(TSut);
            var count = type.GetCustomAttributes(attributeType, true).Count();
            Assert.AreEqual(1, count);
        }
        public static void SutMethodHasAttribute<TSut>(this Fixture fixture, Expression<Action<TSut>> methodExpression, Type attributeType)
        {
            var mi = (MethodInfo)((MethodCallExpression)methodExpression.Body).Method;
            var count = mi.GetCustomAttributes(attributeType, true).Count();
            Assert.AreEqual(1, count);
        }
