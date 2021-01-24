      public static string[] scope =
        {
            CloudSchedulerService.Scope.CloudPlatform
        };
    public static void CreateJob()
        {
     GoogleCredential googleCredential = GoogleCredential.FromFile("filepath").CreateScoped(scope);
                if (googleCredential != null)
                {
                    ICredential credential = googleCredential.UnderlyingCredential;
                    ServiceAccountCredential serviceAccountCredential = credential as ServiceAccountCredential;
                    CloudSchedulerService cloudScheduler = new CloudSchedulerService(new Google.Apis.Services.BaseClientService.Initializer()
                    {
                        HttpClientInitializer = googleCredential,
                        GZipEnabled = false
                    });
                    IDictionary<string, string> header = new Dictionary<string, string>();
                    header.Add("Content-Type", "application/json");
                    header.Add("Authorization", "Bearer "+jobDetails.httpTarget.Authorization);
                    HttpTarget httpTarget = new HttpTarget()
                    {
                        Body = Base64Encode("json string"),
                        Headers = header,
                        HttpMethod = "POST",
                        Uri = "*********"
                    };
                    Job job = new Job()
                    {
                        Description = "",
                        HttpTarget = httpTarget,
                        Name = "projects/" + serviceAccountCredential.ProjectId + "/locations/europe-west3/jobs/" + jobId,
                        Schedule = "5 * * * *", //cron formate
                        TimeZone = "Asia/Kuwait"
                    };
                    cloudScheduler.Projects.Locations.Jobs.Create(job, "projects/" + serviceAccountCredential.ProjectId + "/locations/europe-west3").Execute();
}
}
