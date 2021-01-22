    public static class C1WrappingExtensions {
        public static void Func1(this object instance) {
            C1.Func(instance);
        }
    }
    // Now you can just call Func1() on any object...
    var me = new Whatever();
    me.Func1();
