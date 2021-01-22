    using System;
    using System.Collections.Generic;
    using Microsoft.Build.Framework;
    
    public class FakeBuildEngine : IBuildEngine
    {
    
        // It's just a test helper so public fields is fine.
        public List<BuildErrorEventArgs> LogErrorEvents = new List<BuildErrorEventArgs>();
        public List<BuildMessageEventArgs> LogMessageEvents = 
            new List<BuildMessageEventArgs>();
        public List<CustomBuildEventArgs> LogCustomEvents = 
            new List<CustomBuildEventArgs>();
    
        public List<BuildWarningEventArgs> LogWarningEvents =
            new List<BuildWarningEventArgs>();
        public bool BuildProjectFile(
            string projectFileName, string[] targetNames, 
            System.Collections.IDictionary globalProperties, 
            System.Collections.IDictionary targetOutputs)
        {
            throw new NotImplementedException();
        }
    
        public int ColumnNumberOfTaskNode
        {
            get { return 0; }
        }
    
        public bool ContinueOnError
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    
        public int LineNumberOfTaskNode
        {
            get { return 0; }
        }
    
        public void LogCustomEvent(CustomBuildEventArgs e)
        {
            LogCustomEvents.Add(e);
        }
    
        public void LogErrorEvent(BuildErrorEventArgs e)
        {
            LogErrorEvents.Add(e);
        }
    
        public void LogMessageEvent(BuildMessageEventArgs e)
        {
            LogMessageEvents.Add(e);
        }
    
        public void LogWarningEvent(BuildWarningEventArgs e)
        {
            LogWarningEvents.Add(e);
        }
    
        public string ProjectFileOfTaskNode
        {
            get { return "fake ProjectFileOfTaskNode"; }
        }
    
    }
