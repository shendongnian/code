    using System;
    using System.Linq.Expressions;
    static class SomeType
    {
        static void SomeMethod<T>(T value)
        {
            Console.WriteLine(value);
        }
    }
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    static class Program
    {
        static readonly Action<Customer> action = CreateAction<Customer>();
        static void Main()
        {
            Customer cust = new Customer { Id = 123, Name = "Abc" };
            action(cust);
        }
        static Action<T> CreateAction<T>()
        {
            Action<T> result = null;
            var param = Expression.Parameter(typeof(T), "obj");
            foreach( var property in typeof( T ).GetProperties() )
            {
                var propVal = Expression.Property(param, property);
                var call = Expression.Call(typeof(SomeType), "SomeMethod", new Type[] {propVal.Type}, propVal);
                result += Expression.Lambda<Action<T>>(call, param).Compile();
            }
            return result;
        }
    }
