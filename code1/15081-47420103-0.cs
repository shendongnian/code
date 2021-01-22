    using aliasClass = Fully.Qualified.Namespace.Example;
    //Example being the class in the Fully.Qualified.Namespace
    
    public class Test{
      public void Test_Function(){
        aliasClass.DoStuff();
        //aliasClass here representing the Example class thus aliasing
        //aliasClass will be in scope for all code in my Test.cs file
      }
    }
