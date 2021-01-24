    public class Bot
    {
        Competition Comp { get; set; }
        System.Thread _thread;
        private int _instance;
        
        public Bot()
        {
            Comp = new Competition ();
        }
        public void Start(int instance) 
        {
            _instance = instance;
            _thread = new Thread(StartAsync);
            _thread.Start();
        }
        
        private void StartAsync() 
        {
             string url = "";
    
             //based on the instance I take the data from different source.
             switch(_instance)
             {
                 case 0:
                    url = "www.google.com";
                    break;
                 case 1:
                    url = "www.bing.com";
                    break;
             }
    
             //Comp property contains different groups.
             GetCompetitionAsync(Comp, url);
    
             if(Comp.Groups.Count > 0)
             {
                 foreach(var gp in group)
                 {
                    //add data inside database.
                 }
             }
         }
    
         public List<string> GetCompetitionAsync(Competition comp, string url)
         {
              if(comp.groups == null)  comp.groups = new List<string>();
         
              using (var httpResonse = httpClient.GetAsync(url))
              {
                 string content = await httpResponse.Content.ReadAsStringAsync();
                 //fill list groups
              }
              return groups;
         }
    }
