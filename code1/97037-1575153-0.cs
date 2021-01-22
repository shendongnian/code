    static class Program
    {
        static string code = @"
            public static class __CompiledExpr__
            {{
                public static {0} Run({1})
                {{
                    return {2};
                }}
            }}
            ";
        static MethodInfo ToMethod(string expr, Type[] argTypes, string[] argNames, Type resultType)
        {
            StringBuilder argString = new StringBuilder();
            for (int i = 0; i < argTypes.Length; i++)
            {
                if (i != 0) argString.Append(", ");
                argString.AppendFormat("{0} {1}", argTypes[i].FullName, argNames[i]);
            }
            string finalCode = string.Format(code, resultType != null ? resultType.FullName : "void",
                argString, expr);
            var parameters = new CompilerParameters();
            parameters.ReferencedAssemblies.Add("mscorlib.dll");
            parameters.ReferencedAssemblies.Add(Path.GetFileName(Assembly.GetExecutingAssembly().Location));
            parameters.GenerateInMemory = true;
            var c = new CSharpCodeProvider();
            CompilerResults results = c.CompileAssemblyFromSource(parameters, finalCode);
            var asm = results.CompiledAssembly;
            var compiledType = asm.GetType("__CompiledExpr__");
            return compiledType.GetMethod("Run");
        }
        static Action ToAction(this string expr)
        {
            var method = ToMethod(expr, new Type[0], new string[0], null);
            return () => method.Invoke(null, new object[0]);
        }
        static Func<TResult> ToFunc<TResult>(this string expr)
        {
            var method = ToMethod(expr, new Type[0], new string[0], typeof(TResult));
            return () => (TResult)method.Invoke(null, new object[0]);
        }
        static Func<T, TResult> ToFunc<T, TResult>(this string expr, string arg1Name)
        {
            var method = ToMethod(expr, new Type[] { typeof(T) }, new string[] { arg1Name }, typeof(TResult));
            return (T arg1) => (TResult)method.Invoke(null, new object[] { arg1 });
        }
        static Func<T1, T2, TResult> ToFunc<T1, T2, TResult>(this string expr, string arg1Name, string arg2Name)
        {
            var method = ToMethod(expr, new Type[] { typeof(T1), typeof(T2) },
                new string[] { arg1Name, arg2Name }, typeof(TResult));
            return (T1 arg1, T2 arg2) => (TResult)method.Invoke(null, new object[] { arg1, arg2 });
        }
        static Func<T1, T2, T3, TResult> ToFunc<T1, T2, T3, TResult>(this string expr, string arg1Name, string arg2Name, string arg3Name)
        {
            var method = ToMethod(expr, new Type[] { typeof(T1), typeof(T2), typeof(T3) },
                new string[] { arg1Name, arg2Name, arg3Name }, typeof(TResult));
            return (T1 arg1, T2 arg2, T3 arg3) => (TResult)method.Invoke(null, new object[] { arg1, arg2, arg3 });
        }
        static void Main(string[] args)
        {
            var f = "x + y * z".ToFunc<int, int, long, long>("x", "y", "z");
            var x = f(3, 6, 8);
        }
    }
