    interface ITable
    {
       void SomeCommonFunction ();
    }
    class Table<T> : ITable
    {
       void SomeCommonFunction () { do something - T is known at compile time! }
    }
    class Program
    {
       static void Main(string[] args)
       {
          var tables = new Dictionary<string, ITable>();
          ... //insert tables
          tables["my table"].SomeCommonFunction ();
       }
    }
   
