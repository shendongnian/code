    using System;
    using System.Collections.Generic;
    using SourceSafeTypeLib;
    namespace YourNamespace
    {
  
    public class SourceSafeDatabase 
    {
        private readonly string dbPath;
        private readonly string password;
        private readonly string rootProject;
        private readonly string username;
        private readonly VSSDatabaseClass vssDatabase;
        public SourceSafeDatabase(string dbPath, string username, string password, string rootProject)
        {
            this.dbPath = dbPath;
            this.username = username;
            this.password = password;
            this.rootProject = rootProject;
            vssDatabase = new VSSDatabaseClass();
        }  
        public List<string> GetAllLabels()
        {
            List<string> allLabels = new List<string>();
            VSSItem item = vssDatabase.get_VSSItem(rootProject, false);
            IVSSVersions versions = item.get_Versions(0);
            foreach (IVSSVersion version in versions)
            {
                if (version.Label.Length > 0)
                {
                    allLabels.Add(version.Label);
                }
            }
            return allLabels;
        }
        public void GetLabelledVersion(string label, string project, string directory)
        {
            string outDir = directory;
            vssDatabase.get_VSSItem(rootProject, false).get_Version(label).Get(ref outDir, (int)VSSFlags.VSSFLAG_RECURSYES + (int)VSSFlags.VSSFLAG_USERRONO);
        }
        public void Open()
        {
            vssDatabase.Open(dbPath, username, password);
        }
        public void Close()
        {
            vssDatabase.Close();
        }
    }
    // some other code that uses it
    SourceSafeDatabase sourceControlDatabase = new sourceControlDatabase(...);
    sourceControlDatabase.Open();
    sourceControlDatabase.GetLabelledVersion(label, rootProject, projectDirectory);
    sourceControlDatabase.Close();
