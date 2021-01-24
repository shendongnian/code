    [WMIClass(Name = "Win32_Process", Namespace = "root\\CimV2")]
    public class Process
    {
        public int Handle { get; set; }
        public string Name { get; set; }
        public int ProcessID { get; set; }
        public string ExecutablePath { get; set; }
        public int Priority { get; set; }
        /// <summary>
        /// Date the process begins executing.
        /// </summary>
        public DateTime CreationDate { get; set; }
        public dynamic GetOwnerSid()
        {
            return WMIMethod.ExecuteMethod(this);
        }
        public ProcessOwner GetOwner()
        {
            return WMIMethod.ExecuteMethod<ProcessOwner>(this);
        }
        public int AttachDebugger()
        {
            return WMIMethod.ExecuteMethod<int>(this);
        }
    }
    public class ProcessOwner
    {
        public string Domain { get; set; }
        public int ReturnValue { get; set; }
        public string User { get; set; }
    }
