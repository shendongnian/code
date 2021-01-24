    public class test{
    static void Main(string[] args){
        int a = 30;
        object o = a;
        AlterObject(ref o);
        System.Console.WriteLine(o);
        System.Console.Read();
    }
    static void AlterObject(object testO){
        int b = 130;
        testO = b;
    }
	static void AlterObject(ref object testO){
        int b = 130;
        testO = b;
    }
    }
