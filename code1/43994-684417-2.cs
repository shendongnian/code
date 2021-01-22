    class YourClass
    {
        public static Task<string> SendIncompleteNotification
        {
            get {
                return new Task<string>(
                    s => Console.WriteLine("Executing task... arguments: {0}", s),
                    "My task");
            }
        }
    }
    interface ITask
    {
        void Execute(object o);
    }
    class Task<T> : ITask
    {        
        public Task(Action<T> action, string name)
        {
            Action = action;
        }
        public string Name { get; set; }
        public Action<T> Action { get; set; }
        void ITask.Execute(object o)
        {
            Action((T)o);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Assume that this is what is stored in the database
            var typeName = typeof (YourClass).FullName;
            var propertyName = "SendIncompleteNotification";
            var arguments = "some arguments";
            // Execute the task
            var type = Type.GetType(typeName);
            var property = type.GetProperty(propertyName);
            var task = (ITask)property.GetValue(null, null);
            task.Execute(arguments);
            Console.ReadKey();
        }
    }
