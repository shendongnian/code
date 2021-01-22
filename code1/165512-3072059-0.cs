        bool foo(int p) {Console.WriteLine("foo(int)=" + p); return p == 0;}
        bool foo(string p) {Console.WriteLine("foo(string)=" + p); return p == "";}
        bool foo(double p) { Console.WriteLine("foo(double)=" + p); return p == 0.0; }
        
        bool bar(int p) {Console.WriteLine("bar(int)=" + p); return p == 1;}
        bool bar(string p) { Console.WriteLine("bar(string)=" + p); return p == ""; }
        bool bar(double p) { Console.WriteLine("bar(double)=" + p); return p == 1.1; }
        
        void baz(int p) {Console.WriteLine("baz(int)=" + p);}
        void baz(string p) { Console.WriteLine("baz(string)=" + p); }
        void baz(double p) { Console.WriteLine("baz(double)=" + p); }
        //these object overloads of foo/bar/baz allow runtime overload resolution
        bool foo(object p)
        {
            if(p == null) //we need the type info from an instance
                throw new ArgumentNullException();
            //may memoize MethodInfo by type of p
            MethodInfo mi = typeof(Program).GetMethod(
                "foo", 
                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic, 
                null, 
                new Type[] { p.GetType() }, 
                null
            );
            if (mi.GetParameters()[0].ParameterType == typeof(object))
                throw new ArgumentException("No non-object overload found");
            return (bool)mi.Invoke(this, new object[] { p });
        }
        bool bar(object p)
        {
            if (p == null)
                throw new ArgumentNullException();
            MethodInfo mi = typeof(Program).GetMethod(
                "bar",
                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic,
                null,
                new Type[] { p.GetType() },
                null
            );
            if (mi.GetParameters()[0].ParameterType == typeof(object))
                throw new ArgumentException("No non-object overload found");
            return (bool)mi.Invoke(this, new object[] { p });
        }
        void baz(object p)
        {
            if (p == null)
                throw new ArgumentNullException();
            MethodInfo mi = typeof(Program).GetMethod(
                "baz",
                BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic,
                null,
                new Type[] { p.GetType() },
                null
            );
            if (mi.GetParameters()[0].ParameterType == typeof(object))
                throw new ArgumentException("No non-object overload found");
            mi.Invoke(this, new object[] { p });
        }
        //now you don't need to enumerate your identical implementations of g by type
        void g(object p1) { if (foo(p1)) baz(p1); }
        void g(object p1, object p2) { if (foo(p1)) baz(p1); if (bar(p2)) baz(p2); }
