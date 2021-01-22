    class Program
    {
        static void Main()
        {
            var a = new DataTable {Columns = {{"FirstName", typeof (string)}, {"Age", typeof (int)}}, Rows = {{"Alice", 31}, {"Bob", 42}}};
            var b = new DataTable {Columns = {{"FirstName", typeof (string)}, {"Age", typeof (int)}}, Rows = {{"Alice", 31}, {"Carol", 53}}};
            var diffs = a.SymmetricDifference(b);
            Console.Write(diffs.Rows.Count);
        }
    }
    public static class DataTableExtensions
    {
        public static DataTable SymmetricDifference(this DataTable a, DataTable b)
        {
            var diff = a.Clone();
            foreach (var person in a.AsPersonList().SymmetricDifference(b.AsPersonList()))
            {
                diff.Rows.Add(person.FirstName, person.Age);
            }
            return diff;
        }
        private static IEnumerable<Person> SymmetricDifference(this IEnumerable<Person> a, IEnumerable<Person> b)
        {
            return a.SymmetricDifference(b, new PersonComparer());
        }
        private static IEnumerable<T> SymmetricDifference<T>(this IEnumerable<T> a, IEnumerable<T> b, IEqualityComparer<T> comparer)
        {
            return a.Except(b, comparer).Concat(b.Except(a, comparer));
        }
        private static IEnumerable<Person> AsPersonList(this DataTable table)
        {
            return table.AsEnumerable().Select(row => row.AsPerson()).ToList();
        }
        private static Person AsPerson(this DataRow row)
        {
            return new Person
                       {
                           FirstName = row.Field<string>("FirstName"),
                           Age = row.Field<int>("Age")
                       };
        }
    }
    public class PersonComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person a, Person b)
       {
            return a.FirstName == b.FirstName && a.Age == b.Age;
       }
       public int GetHashCode(Person item)
       {
            return StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.FirstName)
                   + StringComparer.InvariantCultureIgnoreCase.GetHashCode(item.Age);
       }
    }
    public class Person
    {
        public string FirstName;
        public int Age;
    }
