        /// <summary>
        /// Find out if a child type implements or inherits from the parent type.
        /// The parent type can be an interface or a concrete class, generic or non-generic.
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            var currentChild = parent.IsGenericTypeDefinition && child.IsGenericType ? child.GetGenericTypeDefinition() : child;
            
            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;
                currentChild = currentChild.BaseType != null && parent.IsGenericTypeDefinition && currentChild.BaseType.IsGenericType
                                    ? currentChild.BaseType.GetGenericTypeDefinition()
                                    : currentChild.BaseType;
                if (currentChild == null)
                    return false;
            }
            return false;
        }
        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces().Any(childInterface =>
                {
                    var currentInterface = parent.IsGenericTypeDefinition && childInterface.IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;
                    return currentInterface == parent;
                });
        }
        [Test]
        public void ShouldInheritOrImplementNonGenericInterface()
        {
            Assert.That(typeof(FooImplementor)
                .InheritsOrImplements(typeof(IFooInterface)), Is.True);
        }
        [Test]
        public void ShouldInheritOrImplementGenericInterface()
        {
            Assert.That(typeof(GenericFooBase)
                .InheritsOrImplements(typeof(IGenericFooInterface<>)), Is.True);
        }
        [Test]
        public void ShouldInheritOrImplementGenericInterfaceByGenericSubclass()
        {
            Assert.That(typeof(GenericFooImplementor<>)
                .InheritsOrImplements(typeof(IGenericFooInterface<>)), Is.True);
        }
        [Test]
        public void ShouldInheritOrImplementGenericInterfaceByGenericSubclassNotCaringAboutGenericTypeParameter()
        {
            Assert.That(new GenericFooImplementor<string>().GetType()
                .InheritsOrImplements(typeof(IGenericFooInterface<>)), Is.True);
        }
        [Test]
        public void ShouldNotInheritOrImplementGenericInterfaceByGenericSubclassNotCaringAboutGenericTypeParameter()
        {
            Assert.That(new GenericFooImplementor<string>().GetType()
                .InheritsOrImplements(typeof(IGenericFooInterface<int>)), Is.False);
        }
        [Test]
        public void ShouldInheritOrImplementNonGenericClass()
        {
            Assert.That(typeof(FooImplementor)
                .InheritsOrImplements(typeof(FooBase)), Is.True);
        }
        [Test]
        public void ShouldInheritOrImplementAnyBaseType()
        {
            Assert.That(typeof(GenericFooImplementor<>)
                .InheritsOrImplements(typeof(FooBase)), Is.True);
        }
        [Test]
        public void ShouldInheritOrImplementTypedGenericInterface()
        {
            GenericFooImplementor<int> obj = new GenericFooImplementor<int>();
            Type t = obj.GetType();
            Assert.IsTrue(t.InheritsOrImplements(typeof(IGenericFooInterface<int>)));
            Assert.IsFalse(t.InheritsOrImplements(typeof(IGenericFooInterface<String>)));
        } 
