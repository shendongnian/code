    using Microsoft.TeamFoundation.Client; 
    using Microsoft.TeamFoundation.VersionControl.Client; 
    public void MoveFile( string tfsServer, string oldPath, string newPath )
    {
        TeamFoundationServer server = TeamFoundationServerFactory.GetServer( tfsServer, new UICredentialsProvider() ); 
        server.EnsureAuthenticated(); 
        VersionControlServer vcserver = server.GetService( typeof( VersionControlServer ); 
        string currentUserName = server.AuthenticatedUserName;
        string currentComputerName = Environment.MachineName;
        Workspace[] wss = vcserver.QueryWorkspaces(null, currentUserName, currentComputerName);
        foreach (Workspace ws in wss)
        {
                 
            foreach ( WorkingFolder wf in wfs )
            {
                bool bFound = false; 
                if ( wf.LocalItem != null )
                {
                    if ( oldPath.StartsWith( wf.LocalItem ) )
                    {
                       bFound = true; 
                       ws.PendRename( oldPath, newPath ); 
                       break; 
                    }
                 }
                if ( bFound )
                   break; 
            }
        }
    }
