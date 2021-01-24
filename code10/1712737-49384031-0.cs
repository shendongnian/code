    private async void exportButton_Click(object sender, RoutedEventArgs e)
    {
      var dataExtractor = new DataExtractor();
    
      // First API call
      await dataExtractor.ExportTestStepsAsync(testblockId, testCase);
    
      // Second API call
      await dataExtractor.ExportReportTestStepsAsync(testCase, executionList);
    }
    
    public class DataExtractor
    {
       public async Task ExportTestStepsAsync(string testblockId, string testCaseUniqueId)
       {
         ...
         await new QualityMonitorApi().StoreReportItemAsync(content);
       }
    
       public async Task ExportReportTestStepsAsync(string testCaseUniqueId, ExecutionList executionList)
       {
         ...
        await new QualityMonitorApi().StoreReportItemAsync(content);
       }     
    }
    public class QualityMonitorApi
    {
      private string baseUrl = "http://localhost:3000/api/v1";
      private static readonly HttpClient Client = new HttpClient();
    
      public async Task StoreReportItemAsync(string content)
      {
        string url = baseUrl + "/data_extractor/store_report_item";
    
        var json = new StringContent(content, Encoding.UTF8, "application/json");
        await Client.PostAsync(url, json);
      }
    }
