    class HelloWorld {
       int i;
       public HelloWorld(int i) { this.i = i; }
       public static void Print(HelloWorld instance) {
          Console.WriteLine(instance.i);
       }
    }
    var test = new HelloWorld(1);
    var test2 = new HelloWorld(2);
    HelloWorld.Print(test);
