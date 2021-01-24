    public static void Main(string[] args)
    {
      List<Employee> list = new List<Employee>();
      list = list
        // Here we are using equivalent of a subquery, but in order to include new column,
        // we use Tuple here. You can read about Tuples on Micsorosft pages and this site.
        // You can even name items in Tuple, but I leave it up to you.
        .Select(e => (e.ID, e.MOTHER, e.COR_N_ID, list.Count(innerEmployee => innerEmployee.MOTHER == e.ID)))
        // Now we can use result of our "subquery" in where method.
        .Where(e => e.Item4 == 0 && e.COR_N_ID == 99)
        .ToList();
    }
    
    // Sample class for presentation needs :)
    public class Employee
    {
      public int ID;
      public int MOTHER;
      public int COR_N_ID;
    }
