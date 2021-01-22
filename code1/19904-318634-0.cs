    using System;
    using System.Collections.Generic; 
    using System.Text; 
    using System.Management; 
    class ProcessObserver : IDisposable 
    { 
        ManagementEventWatcher m_processStartEvent = null; 
        ManagementEventWatcher m_processStopEvent = null; 
        public ProcessObserver(string processName, EventArrivedEventHandler onStart, EventArrivedEventHandler onStop) 
        { 
            WqlEventQuery startQuery = new WqlEventQuery("Win32_ProcessStartTrace", String.Format("ProcessName='{0}'", processName)); 
            m_processStartEvent = new ManagementEventWatcher(startQuery); 
            WqlEventQuery stopQuery = new WqlEventQuery("Win32_ProcessStopTrace", String.Format("ProcessName='{0}'", processName)); 
            m_processStopEvent = new ManagementEventWatcher(stopQuery); 
            if (onStart != null) 
                m_processStartEvent.EventArrived += onStart; 
            if (onStop != null) 
                m_processStopEvent.EventArrived += onStop; 
        } 
        public void Start() 
        { 
            m_processStartEvent.Start(); 
            m_processStopEvent.Start(); 
        } 
        public void Dispose() 
        { 
            m_processStartEvent.Dispose(); 
            m_processStopEvent.Dispose(); 
        } 
    }
