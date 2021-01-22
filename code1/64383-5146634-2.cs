    public delegate void MD();
    public void Test() {
            // A is the base class you want to call the method.
            A a = new A();
            // Create your delegate using the method name "M" with the instance 'a' of the base class
            MD am = (MD)Delegate.CreateDelegate(typeof(MD), a, "M");
            // Get the target of the delegate and set it to your object (this in most case)
            am.GetType().BaseType.BaseType.GetField("_target", BindingFlags.Instance BindingFlags.NonPublic).SetValue(am, this);
            // call the method using the delegate.
            am();
        }
