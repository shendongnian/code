    class EventLogAdapter
    {
        //vars
        private string _EventProgram = "";
        private string _EventSource = "";
        private string _ProgramName = "";
        private string _ProgramVersion = "";
        private string _EventClass = "";
        private string _EventMethod = "";
        private int _EventCode = 1;
        private bool _Initialized = false;
        private System.Diagnostics.EventLog oEventLog = new EventLog();
        // methods
        public EventLogAdapter() {  }
        public EventLogAdapter(
              string EventProgram
            , string EventSource
            , string ProgramName
            , string ProgramVersion
            , string EventClass
        ) {
            this.SetEventProgram(EventProgram);
            this.SetEventSource(EventSource);
            this.SetProgramName(ProgramName);
            this.SetProgramVersion(ProgramVersion);
            this.SetEventClass(EventClass);
            this.InitializeEventLog();
        }
        public void InitializeEventLog() {
            try {
                if(
                    !String.IsNullOrEmpty(this._EventSource)
                    && !String.IsNullOrEmpty(this._EventProgram)
                ){
                    if (!System.Diagnostics.EventLog.SourceExists(this._EventSource)) {
                        System.Diagnostics.EventLog.CreateEventSource(
                            this._EventSource
                            , this._EventProgram
                        );
                    }
                    this.oEventLog.Source = this._EventSource;
                    this.oEventLog.Log = this._EventProgram;
                    this._Initialized = true;
                }
            } catch { }
        }
        public void WriteEntry(string Message, System.Diagnostics.EventLogEntryType EventEntryType) {
            try {
                string _message = 
                    "[" + this._ProgramName + " " + this._ProgramVersion + "]"
                    + "." + this._EventClass + "." + this._EventMethod + "():\n"
                    + Message;
                this.oEventLog.WriteEntry(
                      Message
                    , EventEntryType
                    , this._EventCode
                );
            } catch { }
        }
        public void SetMethodInformation(
            string EventMethod
            ,int EventCode
        ) {
            this.SetEventMethod(EventMethod);
            this.SetEventCode(EventCode);
        }
        public string GetEventProgram() { return this._EventProgram; }
        public string GetEventSource() { return this._EventSource; }
        public string GetProgramName() { return this._ProgramName; }
        public string GetProgramVersion() { return this._ProgramVersion; }
        public string GetEventClass() { return this._EventClass; }
        public string GetEventMethod() { return this._EventMethod; }
        public int GetEventCode() { return this._EventCode; }
        public void SetEventProgram(string EventProgram) { this._EventProgram = EventProgram; }
        public void SetEventSource(string EventSource) { this._EventSource = EventSource; }
        public void SetProgramName(string ProgramName) { this._ProgramName = ProgramName; }
        public void SetProgramVersion(string ProgramVersion) { this._ProgramVersion = ProgramVersion; }
        public void SetEventClass(string EventClass) { this._EventClass = EventClass; }
        public void SetEventMethod(string EventMethod) { this._EventMethod = EventMethod; }
        public void SetEventCode(int EventCode) { this._EventCode = EventCode; }
    }
