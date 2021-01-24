Install-Package Microsoft.AspNet.WebApi.Client
    if (response.IsSuccessStatusCode)
    {
        RootClass rootClass = await response.Content.ReadAsAsync<RootClass>();
        List<StudentInfo> studentInfos = rootClass.data;
    }
    
