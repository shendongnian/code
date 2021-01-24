    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.TeamFoundation.VersionControl.Client;
    using Microsoft.TeamFoundation.Client;
    using System.Net;
    
    namespace Model.versionControl
    {
        public static class CreateBranch
        {
            
                public static void CreateBranchWithComment()
                {
                    NetworkCredential cre = new NetworkCredential("userName", "password", "domain");
                    TfsTeamProjectCollection tfs = new TfsTeamProjectCollection(new Uri("http://TFSServerName:8080/tfs/CollectionName"), cre);
                    VersionControlServer vcServer = (VersionControlServer)tfs.GetService(typeof(VersionControlServer));
                    int changesetId = vcServer.CreateBranch(@"$/SourceControl/WebSites", "$/SourceControl/WebSites_Branch", VersionSpec.Latest);
                    new WorkspaceVersionSpec("machineName","domain\userName");
                    Changeset changeset = vcServer.GetChangeset(changesetId);
                    
                    changeset.Update();
    
        }
            
        }
    }
