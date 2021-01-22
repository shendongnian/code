    public class TestNameRetriever : ConsoleNameRetriever {
         // This should give you the idea...
         private string[] names = new string[] { "Foo", "Foo2", ... };
         private int index = 0;
         public override string GetNextName()
         {
             return names[index++];
         }
    }
