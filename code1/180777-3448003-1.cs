    public class ReflectionHelper
    {
        public static FieldReader<T> GetFieldReader<T>()
        {
            Type t = typeof(T);
            string className = t.Name;
            string readerClassName = Regex.Replace(className, @"\W+", "_") + "_FieldReader";
            object[] fields = new object[10];
            string source = GetFieldReaderCode(t.Namespace, className, readerClassName, fields);
            CompilerParameters prms = new CompilerParameters();
            prms.GenerateInMemory = true;
            prms.ReferencedAssemblies.Add("System.Data.dll");
            prms.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().GetModules(false)[0].FullyQualifiedName);
            prms.ReferencedAssemblies.Add(t.Module.FullyQualifiedName);
            prms.ReferencedAssemblies.Add("FooLibrary1.dll");
            CompilerResults compiled = new CSharpCodeProvider().CompileAssemblyFromSource(prms, new string[] { source });
            if (compiled.Errors.Count > 0)
            {
                StringWriter w = new StringWriter();
                w.WriteLine("Error(s) compiling {0}:", readerClassName);
                foreach (CompilerError e in compiled.Errors)
                    w.WriteLine("{0}: {1}", e.Line, e.ErrorText);
                w.WriteLine();
                w.WriteLine("Generated code:");
                w.WriteLine(source);
                throw new Exception(w.GetStringBuilder().ToString());
            }
            return (FieldReader<T>)compiled.CompiledAssembly.CreateInstance(readerClassName);
        }
        private static string GetFieldReaderCode(string ns, string className, string readerClassName, IEnumerable<object> fields)
        {
            StringWriter w = new StringWriter();
            // write out field setters here
            return @"   
    using System;   
    using System.Data;   
    namespace " + ns + ".Generated   
    {    
       public class " + readerClassName + @" : FieldReader<" + className + @">    
       {        
             public override void Fill(" + className + @" e, IDataReader reader)          
             " + w.GetStringBuilder().ToString() +         
       }    
    }";        
