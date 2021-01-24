    public class NeedsFooFactory
    {
        private readonly IFooBarFactory _factory;
        public NeedsFooFactory(IFooBarFactory fooBarFactory)
        {
            _factory = factory;
        }
        public void WhatEverThisClassDoes(IFoo foo)
        {
            var fooBar = _factory.Create(foo);
            // Do something
        }
    }
