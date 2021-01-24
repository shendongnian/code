    static void Main(string[] args)
    {
        MainAsync(args).GetAwaiter().GetResult();
    }
        static async Task MainAsync(string[] args)
        {
            DataSet ds = new DataSet();
            /*logic for getting dataset values.table0 contains posting file details
            and Table1 contains details of files which need response*/
            //"starting Posting files to API";
            await PostDatas(ds);
            //"Ending Posting files to API";
            //"Getting Response from the API";
            await GetResponseXML(ds);
            //"Ending Getting Response from the API";
        }
        public async static Task PostDatas(DataSet ds)
        {
            var client = new HttpClient();
            List<Task<HttpResponseMessage>> tasks = new List<Task<HttpResponseMessage>>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                
                //post the files 
                tasks.Add(client.PostAsync(URL, ReqClass, bsonFormatter));
                
            }
            await Task.whenAll(tasks);
            foreach(var response in tasks)
            {
                 HttpResponseMessage message = response.Result;
                 //etc.
 
            }
        }
        
    }
