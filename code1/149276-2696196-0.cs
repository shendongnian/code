    public class MyClass 
    { 
        public int A { get; set; }
        public int B { get; set; }
    }
    public void Main()
    {
        using (DBDataContext context = new DBDataContext())
        {
          var result = context.TableAs.Join(
             context.TableBs,
             a => a.BID,
             b => b.ID,
            (a,b) => new MyClass {A = a, B = b}
          );
          result = addNeedValue(result, 4);
       }
    }
    private IQueryable<MyClass> addNeedValue(IQueryable<MyClass> result, int value)
    {
        return result.Where(r => r.A.Value == value);
    }
