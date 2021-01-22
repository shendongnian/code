    internal class Program
    {
        private static void Main(string[] args)
        {
            var dc = new AdventureWorksLT2008Entities();
            object c;
            dc.TryGetObjectByKey(GetEntityKey(dc.Customers, 23), out c);
            var customer = c as Customer;
            Console.WriteLine(customer.EmailAddress);
        }
        private static EntityKey GetEntityKey<T>(ObjectSet<T> objectSet, object keyValue) where T : class
        {
            var entitySetName = objectSet.Context.DefaultContainerName + "." + objectSet.EntitySet.Name;
            var keyPropertyName = objectSet.EntitySet.ElementType.KeyMembers[0].ToString();
            var entityKey = new EntityKey(entitySetName, new[] {new EntityKeyMember(keyPropertyName, keyValue)});
            return entityKey;
        }
    }
