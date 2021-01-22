    class FooHolder
    {
        public static DependencyProperty CurrentFooProperty = WpfUtils.RegisterDependencyPropertyWithCallback
            <FooHolder, Foo>("CurrentFoo", x => x.OnCurrentFooChanged);
        private void OnCurrentFooChanged(Foo oldFoo, Foo newFoo)
        {
            // do stuff with holder
        }
    }
