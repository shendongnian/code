    public interface I1_I2 : I1, I2 { }
    public class C_I1_I2 : C, I1_I2 { }
    public static void Main() {
        I1_I2 c = new C_I1_I2();
        c.F1();    // ok
        c.F2();    // ok
    //  c.F3();    // error is ok
    }
