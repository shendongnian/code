    class SomeClass {
        private volatile Object myObject = new Object();
        private void HandleObject(Object theObject) {
            // The `theObject` argument is a copy of the passed variable
            // and the following line won't change the actual variable's
            // value, but the local instance.
            theObject = new Object();
        }
        private void HandleObjectRef(ref Object theObject) {
            // The actual variable's value will be changed, when the
            // following line is executed.
            theObject = new Object();
        }
        public void DoSomething() {
            // This call is safe, the `myObject` variable won't be
            // changed after when `HandleObject` is executed.
            this.HandleObject(myObject);
            // The `myObject` will be changed after when `HandleObjectRef`
            // is executed. (WARNING)
            this.HandleObjectRef(ref myObject);
        }
    }
