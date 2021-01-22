    public class MyForm<T>
    {
       private readonly Func<T, bool> predicate;
       public MyForm(Func<T, bool> predicate) { this.predicate = predicate }
       private void SomeMethod()
       {
           bool result = predicate();
           // Do something
       }
    }
    var form = new MyForm(x => x.Number < 5);
