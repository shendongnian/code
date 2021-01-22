    using System;
    using IronRuby;
    using Microsoft.Scripting.Hosting;
    class IronRubyReflection
    {
        static void Main(string[] args)
        {
            var engine = Ruby.CreateEngine();
            var scope = engine.ExecuteFile("libtest.rb");
            dynamic globals = engine.Runtime.Globals;
            var klass = globals.Klass;
            var klass_s = klass.GetOrCreateSingletonClass();
            var modul = globals.Modul;
            var modul_s = modul.GetOrCreateSingletonClass();
            Console.WriteLine(
                scope.GetVariable<IronRuby.Builtins.RubyMethod>(
                    "method_in_the_global_object").Name);
            Action<string, IronRuby.Builtins.RubyModule,
                IronRuby.Runtime.Calls.RubyMemberInfo> classprinter =
                    (n, k, i) => { Console.WriteLine(n, k, i); };
            klass.ForEachMember(false,
                IronRuby.Runtime.RubyMethodAttributes.Default, classprinter);
            klass_s.ForEachMember(false,
                IronRuby.Runtime.RubyMethodAttributes.Default, classprinter);
            modul.ForEachMember(false,
                IronRuby.Runtime.RubyMethodAttributes.Default, classprinter);
            modul_s.ForEachMember(false,
                IronRuby.Runtime.RubyMethodAttributes.Default, classprinter);
            Console.ReadLine();
        }
    }
