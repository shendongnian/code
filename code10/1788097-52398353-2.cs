    public class TFSClient
    {
        public WorkItemTrackingHttpClient WorkItem { get; set; }
        public TFSClient()
        {            
            VssCredentials vssCred = new VssCredentials(new WindowsCredential(true));
            WorkItem = new WorkItemTrackingHttpClient(new Uri(TFSServer.Url), vssCred);
        }
    }
     public static object UpdateWorkItemByID(int id)
        {
            try
            {
                JsonPatchDocument patchDocument = new JsonPatchDocument
                {
                    new JsonPatchOperation()
                    {                       
                        Operation = Operation.Add,
                        Path = ItemField.History,
                        Value = "Teste"
                    }
                };            
                return  new TFSClient().WorkItem.UpdateWorkItemAsync(patchDocument, id).Result;              
    
            }
    
            catch (Exception e)
            {
                throw e;
            }
        }
