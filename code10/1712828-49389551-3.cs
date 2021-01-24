        using System;
        using System.Collections.Generic;
        namespace ConsoleApplication6
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var child1Service = new Child1Service();
                    var child2Service = new Child2Service();
                    var child1Manager = child1Service.GetTradeManager<IChild1Manager>();
                    var child2Manager = child2Service.GetTradeManager<IChild2Manager>();
                    var child1NewManager = child1Service.GetTradeManager<IChild2Manager>();
                }
            }
            public abstract class ParentService
            {
                public T GetTradeManager<T>() where T : IBaseManager
                {
                    Type instanceType = null;
                    GenericHelper.DependencyDictionary.TryGetValue(typeof(T),out instanceType);
                    if (instanceType == null)
                        throw new NotImplementedException("Type Not Implemented");
                    if (!this.GetType().Name.Replace("Service", "").StartsWith(instanceType.Name.Replace("Manager", "")))
                        throw new InvalidOperationException("Not Same Manager");
                    return (T)Activator.CreateInstance(instanceType);
                }
            }
            public class Child1Service : ParentService { }
            public class Child2Service : ParentService { }
            public abstract class BaseManager : IBaseManager
            {
            }
            public interface IBaseManager
            {
            }
            public interface IChild1Manager : IBaseManager { }
            public class Child1Manager : BaseManager, IChild1Manager { }
            public interface IChild2Manager : IBaseManager { }
            public class Child2Manager : BaseManager, IChild2Manager { }
            public static class GenericHelper
            {
                public static Dictionary<Type, Type> DependencyDictionary { get; set; } = new Dictionary<Type, Type>() { { typeof(IChild1Manager), typeof(Child1Manager) }, { typeof(IChild2Manager), typeof(Child2Manager) } };
            }
        }
