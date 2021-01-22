namespace N1
{
    public class ClassA
    {
        string var1 = null;
        private ClassB b;
        public ClassA()
        {
            var1 = "one";
            b = new ClassB(this);
        }
        //property 
        public string Var1
        {
            get { return var1; }
        }
    }
}
namespace N1
{
   internal class ClassB  
   {
       ClassA classA;
       public ClassB(ClassA classARef)
       {
           classA = classARef;
       }
     private void method()
     {
      // I need to access the value of Var1( property) from here, how to do this?
         string myString = classA.Var1;
     }
   }
}
