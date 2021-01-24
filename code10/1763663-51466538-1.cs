    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    [assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default)]
    public class SomeClass {
        public void DoSomething() { }
    }
    public static class DelegateKeeper {
        private static ConditionalWeakTable<object, List<Delegate>> cwt = new ConditionalWeakTable<object, List<Delegate>>();
        public static void KeepAlive(Delegate d) => cwt.GetOrCreateValue(d?.Target ?? throw new ArgumentNullException(nameof(d))).Add(d);
    }
    static class Program {
        static void Main() {
            SomeClass inst = new SomeClass();
            Action a1 = inst.DoSomething;
            DelegateKeeper.KeepAlive(a1);
            Action a2 = inst.DoSomething;
            WeakReference<SomeClass> winst = new WeakReference<SomeClass>(inst);
            WeakReference<Action> wa1 = new WeakReference<Action>(a1);
            WeakReference<Action> wa2 = new WeakReference<Action>(a2);
            GC.Collect();
            Console.WriteLine($"{winst.TryGetTarget(out _),5}:{wa1.TryGetTarget(out _),5}:{wa2.TryGetTarget(out _),5}");
            GC.KeepAlive(a1);
            GC.KeepAlive(a2);
            GC.Collect();
            Console.WriteLine($"{winst.TryGetTarget(out _),5}:{wa1.TryGetTarget(out _),5}:{wa2.TryGetTarget(out _),5}");
            GC.KeepAlive(inst);
            GC.Collect();
            Console.WriteLine($"{winst.TryGetTarget(out _),5}:{wa1.TryGetTarget(out _),5}:{wa2.TryGetTarget(out _),5}");
        }
    }
