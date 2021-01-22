    dynamic wrapper = new Proxy(new Foo());
    IFoo foo = wrapper;
    foo.Bar();
    class Proxy : DynamicObject
    {
        ...
        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            Type bindingType = binder.Type;
            if (bindingType.IsInstanceOfType(target))
            {
                result = target;
                return true;
            }
            result = null;
            return false;
          
        }
    }
