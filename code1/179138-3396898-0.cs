    private abstract class Base<TResult> {
        public abstract TResult Execute();
    }
    private class Derived : Base<bool> {
        //...
        public override bool Execute(){
             return this.myValue;
        }
        //....
    }
    Derived d = new Derived(true);
    bool result = d.Execute(); // This results in a null reference pointer (commented above)
