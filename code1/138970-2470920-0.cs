     MyMethod myMethod = new MyMethod();
     myMethod.doSomething(1);
     public class MyMethod {
          public String doSomething(int a) {
              String p1 = MyMethod.functionA(a);
              String p2 = MyMethod.functionB(p1);
              return p1 + P2;
          }
          public static String functionA(...) {...}
          public static String functionB(...) {...}
     }
