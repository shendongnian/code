        class Root {
           public static virtual string TestMethod() {return "Root"; }
        }
        TRootClass = class of TRoot; // Here is the typed type declaration
        
        class Derived : Root {
           public static overide string TestMethod(){ return "derived"; }
        }
        
       class Test {
            public static string Run(){
               TRootClass rc;
               rc = Root;
               Test(rc);
               rc = Derived();
               Test(rc);
            }
            public static Test(TRootClass AClass){
               string str = AClass.TestMethod();
               Console.WriteLine(str);
            }
        } 
