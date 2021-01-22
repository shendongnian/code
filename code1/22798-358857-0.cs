    interface ILow { void Low();}
    interface IFoo : ILow { void Foo();}
    interface IBar { void Bar();}
    interface ITest : IFoo, IBar { void Test();}
    
    static class Program
    {
        static void Main()
        {
            List<Type> considered = new List<Type>();
            Queue<Type> queue = new Queue<Type>();
            considered.Add(typeof(ITest));
            queue.Enqueue(typeof(ITest));
            while (queue.Count > 0)
            {
                Type type = queue.Dequeue();
                Console.WriteLine("Considering " + type.Name);
                foreach (Type tmp in type.GetInterfaces())
                {
                    if (!considered.Contains(tmp))
                    {
                        considered.Add(tmp);
                        queue.Enqueue(tmp);
                    }
                }
                foreach (var member in type.GetMembers())
                {
                    Console.WriteLine(member.Name);
                }
            }
        }
    }
