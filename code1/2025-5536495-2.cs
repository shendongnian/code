    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    
    
    namespace SingleInstanceController_NET
    {
        public class SingleInstanceController
        : WindowsFormsApplicationBase
        {
            public delegate Form CreateMainForm();
            public delegate void StartNextInstanceDelegate(Form mainWindow);
            CreateMainForm formCreation;
            StartNextInstanceDelegate onStartNextInstance;
            public SingleInstanceController(CreateMainForm formCreation, StartNextInstanceDelegate onStartNextInstance)
            {
                // Set whether the application is single instance
                this.formCreation = formCreation;
                this.onStartNextInstance = onStartNextInstance;
                this.IsSingleInstance = true;
    
                this.StartupNextInstance += new StartupNextInstanceEventHandler(this_StartupNextInstance);                      
            }
    
            void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
            {
                if (onStartNextInstance != null)
                {
                    onStartNextInstance(this.MainForm); // This code will be executed when the user tries to start the running program again,
                                                        // for example, by clicking on the exe file.
                }                                       // This code can determine how to re-activate the existing main window of the running application.
            }
    
            protected override void OnCreateMainForm()
            {
                // Instantiate your main application form
                this.MainForm = formCreation();
            }
    
            public void Run()
            {
                string[] commandLine = new string[0];
                base.Run(commandLine);
            }
        }
    }
