    class MyClass
    {
        // hardcoded, but should be from configuration vars
        private string AppName = "MyApp";
        private string AppVersion = "1.0.0.0";
        private string ClassName = "MyClass";
        private string LogName = "MyApp Log";
        EventLogAdapter oEventLogAdapter;
        EventLogEntryType oEventLogEntryType;
        
        public MyClass(){
            this.oEventLogAdapter = new EventLogAdapter(
                  this.AppName
                , this.LogName
                , this.AppName
                , this.AppVersion
                , this.ClassName
            );
        }
        private bool MyFunction() {
            bool result = false;
            this.oEventLogAdapter.SetMethodInformation("MyFunction", 100);
            try {
                // do stuff
                this.oEventLogAdapter.WriteEntry("Something important found out...", EventLogEntryType.Information);
            } catch (Exception oException) {
                this.oEventLogAdapter.WriteEntry("Error: " + oException.ToString(), EventLogEntryType.Error);
            }
            return result;
        }
    }
