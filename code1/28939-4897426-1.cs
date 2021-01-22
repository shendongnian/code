    protected interface IFooInterface
        {
        }
        protected interface IGenericFooInterface<T>
        {
        }
        protected class FooBase
        {
        }
        protected class FooImplementor : FooBase, IFooInterface
        {
        }
        protected class GenericFooBase : FooImplementor, IGenericFooInterface<object>
        {
            
        }
        protected class GenericFooImplementor<T> : FooImplementor, IGenericFooInterface<T>
        {
        }
    [Test]
        public void Should_inherit_or_implement_non_generic_interface()
        {
            Assert.That(typeof(FooImplementor).InheritsOrImplements(typeof(IFooInterface)), Is.True);
        }
        [Test]
        public void Should_inherit_or_implement_generic_interface()
        {
            Assert.That(typeof(GenericFooBase).InheritsOrImplements(typeof(IGenericFooInterface<>)), Is.True);
        }
        [Test]
        public void Should_inherit_or_implement_generic_interface_by_generic_subclass()
        {
            Assert.That(typeof(GenericFooImplementor<>).InheritsOrImplements(typeof(IGenericFooInterface<>)), Is.True);
        }
        [Test]
        public void Should_inherit_or_implement_generic_interface_by_generic_subclass_not_caring_about_generic_type_parameter()
        {
            Assert.That(new GenericFooImplementor<string>().GetType().InheritsOrImplements(typeof(IGenericFooInterface<>)), Is.True);
        }
        [Test]
        public void Should_not_inherit_or_implement_generic_interface_by_generic_subclass_not_caring_about_generic_type_parameter()
        {
            Assert.That(new GenericFooImplementor<string>().GetType().InheritsOrImplements(typeof(IGenericFooInterface<int>)), Is.False);
        }
        [Test]
        public void Should_inherit_or_implement_non_generic_class()
        {
            Assert.That(typeof(FooImplementor).InheritsOrImplements(typeof(FooBase)), Is.True);
        }
        [Test]
        public void Should_inherit_or_implement_any_base_type()
        {
            Assert.That(typeof(GenericFooImplementor<>).InheritsOrImplements(typeof(FooBase)), Is.True);
        }
