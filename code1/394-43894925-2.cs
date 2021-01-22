    using Microsoft.Build.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class RefreshVersion : Microsoft.Build.Utilities.Task
    {
        [Output]
        public string NewVersionString { get; set; }
        public string CurrentVersionString { get; set; } 
    
        public override bool Execute()
        {       
            Version currentVersion = new Version(CurrentVersionString ?? "1.0.0");
    
            DateTime d = DateTime.Now;
            NewVersionString = new Version(currentVersion.Major, 
                currentVersion.Minor, currentVersion.Build+1).ToString();
            return true;
        }
    
    }
