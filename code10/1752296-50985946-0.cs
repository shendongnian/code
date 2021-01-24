    public class GetResponse
    {
       public strin dID{ get; set; }
       public string aNumber{ get; set; }
       public services services{ get; set; }
       public string sourceSystem { get; set; }
    }
    public class services 
    {
       public string sIdentifier{ get; set; }
       public List<itemCode> itemCode{ get; set; }      
    }
    public class itemCode
    {
       public string bcode{ get; set; }
       public string ecode{ get; set; }
       public string description{ get; set; }
       public string lDescription{ get; set; }      
    }
      GetResponse  getResponse = JsonConvert.DeserializeObject<GetResponse>(json.ToString());
    //After that you will use foreach loop and get value from modal
 
