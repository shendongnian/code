    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.Remoting.Proxies;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    
    namespace BrokenProxy
    {
        class NotAnIAsyncResult
        {
            public string SomeProperty { get; set; }
        }
    
        class BrokenProxy : RealProxy
        {
            private void HackFlags()
            {
                var flagsField = typeof(RealProxy).GetField("_flags", BindingFlags.NonPublic | BindingFlags.Instance);
                int val = (int)flagsField.GetValue(this);
                val |= 1; // 1 = RemotingProxy, check out System.Runtime.Remoting.Proxies.RealProxyFlags
                flagsField.SetValue(this, val);
            }
    
            public BrokenProxy(Type t)
                : base(t)
            {
                HackFlags();
            }
    
            public override IMessage Invoke(IMessage msg)
            {
                var naiar = new NotAnIAsyncResult();
                naiar.SomeProperty = "o noes";
                return new ReturnMessage(naiar, null, 0, null, (IMethodCallMessage)msg);
            }
        }
    
        interface IRandomInterface
        {
            int DoSomething();
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                BrokenProxy bp = new BrokenProxy(typeof(IRandomInterface));
                var instance = (IRandomInterface)bp.GetTransparentProxy();
                Func<int> doSomethingDelegate = instance.DoSomething;
                IAsyncResult notAnIAsyncResult = doSomethingDelegate.BeginInvoke(null, null);
    
                var interfaces = notAnIAsyncResult.GetType().GetInterfaces();
                Console.WriteLine(!interfaces.Any() ? "No interfaces on notAnIAsyncResult" : "Interfaces");
                Console.WriteLine(notAnIAsyncResult is IAsyncResult); // Should be false, is it?!
                Console.WriteLine(((NotAnIAsyncResult)notAnIAsyncResult).SomeProperty);
                Console.WriteLine(((IAsyncResult)notAnIAsyncResult).IsCompleted); // No way this works.
            }
        }
    }
