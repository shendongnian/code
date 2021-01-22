public class foo : IDisposable 
   {
   public foo() { ; }
   public string Name;
   public void Dispose()  { ; } 
   // Real class would free up instance resources
   }
  LimitedInstance li = LimitedInstance&lt; foo &gt;.CreateInstance();
  li.Instance.Name = "Friendly Name for instance";
  // do stuff with li
  LimitedInstance&lt; foo &gt;.UnloadInstance( ref li );
