    static class Program
    {
        static void Main(string[] args)
        {
            var vm = new MessagesViewModel();
            PropertyInfo[] myProperties = vm.GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.PropertyType == typeof(string) && p.Name.Contains("Msg"))
                .ToArray();
            foreach (var propertyInfo in myProperties)
            {
                //You can also access directly using the indexer --> myProperties[0]..
                propertyInfo.SetValue(vm, $"This is {propertyInfo.Name} property");
            }
            Console.WriteLine(vm.Msg1);
            Console.WriteLine(vm.Msg2);
        }
    }
    public class MessagesViewModel
    {
        string _msg1;
        string _msg2;
        public string Msg1 { get => _msg1; set => _msg1 = value; }
        public string Msg2 { get => _msg2; set => _msg2 = value; }
    }
    
