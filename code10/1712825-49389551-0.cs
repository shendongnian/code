        namespace ConsoleApplication6
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var child1Service = new Child1Service();
                    var child2Service = new Child2Service();
                    var child1Manager = child1Service.GetTradeManager<Child1Manager>();
                    var child2Manager = child2Service.GetTradeManager<Child2Manager>();
                    var child1NewManager = child1Service.GetTradeManager<Child2Manager>();
                }
            }
            public abstract class ParentService
            {
                public T GetTradeManager<T>()
                {
                    if(!this.GetType().Name.Replace("Service","").StartsWith(typeof(T).Name.Replace("Manager","")))
                        throw new InvalidOperationException("Not Same Manager");
                    return Activator.CreateInstance<T>();
            
                }
            }
            public class Child1Service : ParentService { }
            public class Child2Service : ParentService { }
            public abstract class BaseManager
            {
            }
            public class Child1Manager : BaseManager { }
            public class Child2Manager : BaseManager { }
        }
