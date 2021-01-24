        /// <summary> Dynamically create delegate </summary>
        /// <param name="className">Event handler class name</param>
        /// <param name="eventName">Event name</param>
        /// <returns>Delegate</returns>
        private static Delegate CreateDelegate(Type className, string eventName)
        {
            try
            {
                var codeProvider = new CSharpCodeProvider();
                var compilerParameters = new CompilerParameters
                {
                    GenerateExecutable = false,
                    GenerateInMemory = true,
                };
                var assemblies = className.Assembly.GetReferencedAssemblies().ToList();
                assemblies= assemblies.Union(typeof(EventSubscriber).Assembly.GetReferencedAssemblies()).ToList();
                var assemblyLocations = assemblies.Select(a => Assembly.ReflectionOnlyLoad(a.FullName).Location).ToList();
                // Type where event handler
                assemblyLocations.Add(className.Assembly.Location);
                // Type where I'm
                assemblyLocations.Add(typeof(EventSubscriber).Assembly.Location);
                compilerParameters.ReferencedAssemblies.AddRange(assemblyLocations.ToArray());
                // Dynamic part generated from User text(code)
                var executable = string.Format(@"namespace {0} {{ public static class PrivateExecutor{{ public static {1} Create() {{"
                                               + "{1} _result = (sender, args) => Subscriber.Execute(\"{2}\", sender, args);return _result;}}}}}}",
                                               typeof(EventSubscriber).Namespace,
                                               className.FullName,
                                               eventName);
                // Try to compile
                var compilerResults = codeProvider.CompileAssemblyFromSource(compilerParameters, executable);
                // Check compiler errors
                if(compilerResults.Errors.OfType<CompilerError>().Count(e => !e.IsWarning) > 0)
                {
                    var errors = new StringBuilder(string.Empty);
                    foreach(var err in compilerResults.Errors.OfType<CompilerError>())
                        errors.AppendFormat("{0} ", err.ErrorText);
                    throw new ArgumentException(string.Format("Handler : [{0}]. Event : [{1}]. Error : [{2}]", className, eventName, errors).Trim());
                }
                // Get executable method
                var methinfo = compilerResults.CompiledAssembly.GetType(string.Format("{0}.PrivateExecutor", typeof(EventSubscriber).Namespace)).GetMethod("Create");
                return  (Delegate)methinfo.Invoke(null, null);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(string.Format("{0}{1}", ex.Message, ex.InnerException).Trim());
            }
        }
