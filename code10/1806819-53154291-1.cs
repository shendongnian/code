    public void LoadPlugin(params string[] sourceCodeFilesForUserControl)
    {
        // Compile the source files
        CSharpCodeProvider codeProvider = new CSharpCodeProvider();
        CompilerParameters parameters = new CompilerParameters();
        parameters.IncludeDebugInformation = true;
        parameters.GenerateInMemory = true;
        // Add references that they can use
        parameters.ReferencedAssemblies.Add("System.dll");
        parameters.ReferencedAssemblies.Add("System.Core.dll");
        parameters.ReferencedAssemblies.Add("System.Windows.Forms.dll"); // important for UserControl 
        parameters.TreatWarningsAsErrors = false;
        CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, sourceCodeFilesForUserControl);
        if (results.Errors.Count > 0)
        {
            // Handle compile errors
            StringBuilder sb = new StringBuilder();
            foreach (CompilerError CompErr in results.Errors)
            {
                sb.AppendLine("Line number " + CompErr.Line +
                              ", Error Number: " + CompErr.ErrorNumber +
                              ", '" + CompErr.ErrorText + ";");
            }
            Console.Write(sb.ToString());
        }
        else
        {
            // The assembly we can search for a usercontrol
            var assembly = results.CompiledAssembly;
            // If the assembly was already compiled you might want to load it directly:
            // assembly = Assembly.LoadFile(@"C:\Program Files\MyTool\plugins\someplugin.dll");
            // Get the first type in the assembly that is a UserControl
            var userControl = assembly.GetTypes().FirstOrDefault(x => x.BaseType == typeof(UserControl));
            
            // Create a instance of the UserControl
            var createdUserControl = Activator.CreateInstance(userControl, new object[] { }) as UserControl;
            
            // Add the created UserControl to the current form
            this.Controls.Add(createdUserControl);
        }
    }
