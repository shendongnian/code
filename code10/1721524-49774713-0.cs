    using Microsoft.TeamFoundation.Core.WebApi;
    using Microsoft.VisualStudio.Services.Common;
    ...
    //create uri and VssBasicCredential variables
    Uri uri = new Uri(url);
    VssBasicCredential credentials = new VssBasicCredential("", personalAccessToken);
    using (ProjectHttpClient projectHttpClient = new ProjectHttpClient(uri, credentials))
    {
        IEnumerable<TeamProjectReference> projects = projectHttpClient.GetProjects().Result;                    
    }
