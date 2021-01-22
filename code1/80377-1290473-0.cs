            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.ApartmentState = System.Threading.ApartmentState.STA;
            runspace.ThreadOptions = PSThreadOptions.ReuseThread;
            runspace.Open();
            runspace.SessionStateProxy.SetVariable("Application", app);
