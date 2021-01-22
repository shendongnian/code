public class StringEntity
{
   private readonly string value;
   public StringEntity(string value)
      : base()
   {
      this.value = value;
   }
}
...
Assert.IsTrue(Repository.FindAll&lt;StringEntity&gt;().Count() == 0);
Repository.Save(new StringEntity("New String"));
Assert.IsTrue(Repository.FindAll&lt;StringEntity&gt;().Count() == 1);
