public class Primitive&lt;T&gt;
{
   private readonly T value;
   public Primitive(T value)
      : base()
   {
      this.value = value;
   }
}
...
Assert.IsTrue(Repository.FindAll&lt;Primitive&lt;string&gt;&gt;().Count() == 0);
Repository.Save(new Primitive&lt;string&gt;("New String"));
Assert.IsTrue(Repository.FindAll&lt;Primitive&lt;string&gt;&gt;().Count() == 1);
