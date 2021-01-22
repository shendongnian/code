    public class Tester
    {
      public void ShowHowIWantIt()
      {
         TestObjectContext context =  new TestObjectContext();   
         var query = from a in context.AsEager().TestEntity select a;
      }   
    } 
