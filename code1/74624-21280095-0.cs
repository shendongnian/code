    public class WindowsFormsApplication : WindowsFormsApplicationBase
    {
        /// <summary>
        /// Runs the specified mainForm in this application context.
        /// </summary>
        /// <param name="mainForm">Form that is run.</param>
        public virtual void Run(Form mainForm)
        {
            // set up the main form.
            this.MainForm = mainForm;
		
            // Example code
            ((Form1)mainForm).FileName = this.CommandLineArgs[0];
		
            // then, run the the main form.
            this.Run(this.CommandLineArgs);
        }
        /// <summary>
        /// Runs this.MainForm in this application context. Converts the command
        /// line arguments correctly for the base this.Run method.
        /// </summary>
        /// <param name="commandLineArgs">Command line collection.</param>
        private void Run(ReadOnlyCollection<string> commandLineArgs)
        {
            // convert the Collection<string> to string[], so that it can be used
            // in the Run method.
            ArrayList list = new ArrayList(commandLineArgs);
            string[] commandLine = (string[])list.ToArray(typeof(string));
            this.Run(commandLine);
        }
	
    }
    
