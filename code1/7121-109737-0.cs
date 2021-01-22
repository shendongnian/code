    public class MyOtherClass
    {
         //...
         public string GetText()
         {
            using (var h = CreateHelper())
                 return h.Text;
         }
    }
