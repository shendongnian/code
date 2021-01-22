    public class MyClass {}
    public class MySafeClass {
        public void CallMethod(string name, object[] param) {
            Type t = typeof(MyClass);
            MyClass mc = new MyClass();
            try {
                t.GetMethod(name).Invoke(mc, param);
            }
            catch {
                //...;
            }
        }
