    public class BarClass {
        public void BarMethod(Type t) {
            FooClass.FooMethod()          //works fine
            if (t == typeof(FooClass)) {
                t.GetMethod("FooMethod").Invoke(null); //null - means calling static method
            }
        }
    }
