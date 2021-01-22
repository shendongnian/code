I would personally recommend a better design pattern, like the visitor pattern, but for what its worth you can make your code work by throwing away type safety. Use Delegate rather than its derived classes Func and Action:
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            ObjectFactory.Instance.AdornFunctionality(customer, "add");
            Console.WriteLine(customer.CallAlgorithm("add", 64, 36));
            Employee employee = new Employee();
            ObjectFactory.Instance.AdornFunctionality(employee, "add");
            ObjectFactory.Instance.AdornFunctionality(employee, "subtract");
            ObjectFactory.Instance.AdornFunctionality(employee, "save");
            Console.WriteLine(employee.CallAlgorithm("add", 5, 15));
            Console.WriteLine(employee.CallAlgorithm("subtract", 66, 16));
            Console.WriteLine(employee.CallAlgorithm("save"));
            Console.ReadLine();
        }
    }
    public class ObjectFactory
    {
        private static ObjectFactory singleton;
        public void AdornFunctionality(AdornedObject ao, string idCode)
        {
            Func<int, int, int> add = (i, j) => i + j;
            Func<int, int, int> subtract = (i, j) => i - j;
            Action save = () => Console.WriteLine("{0} has been saved", ao.ToString());
            switch (idCode)
            {
                case "add":
                    ao.LoadAlgorithm(idCode, add);
                    break;
                case "subtract":
                    ao.LoadAlgorithm(idCode, subtract);
                    break;
                case "save":
                    ao.LoadAlgorithm(idCode, save);
                    break;
            }
        }
        public static ObjectFactory Instance
        {
            get
            {
                if (singleton == null)
                    singleton = new ObjectFactory();
                return singleton;
            }
        }
    }
    public abstract class AdornedObject
    {
        private Dictionary<string, Delegate> algorithms = new Dictionary<string, Delegate>();
        public void LoadAlgorithm(string idCode, Delegate func)
        {
            algorithms.Add(idCode, func);
        }
        public object CallAlgorithm(string idCode, params object[] args)
        {
            Delegate func = algorithms[idCode];
            return func.DynamicInvoke(args);
        }
    }
