    public interface I1 { }
    public interface I2 { }
    public class C : I1, I2 { }
    public interface I3 : I1, I2 { }
    public class YourClass
    {
        public void Test(I3 i) { }
    }
    ...
    YourClass yc = new YourClass();
    C c = new C();
    yc.Test(c); // won't work, C does not implement I3
