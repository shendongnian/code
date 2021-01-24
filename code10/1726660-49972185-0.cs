    Public class TraderFields {
       public string Users {get; set;}  
       public string macaddress_value {get; set; }
       public string email_value {get;set;}
    }
    Public class TraderRecord {
       public string id {get;set;}
       public TraderFields fields {get;set;} = New TraderFields();
       public DateTime createdTime {get;set;}
    }
    Public class TraderData {
       public List<TraderRecord> records {get; set; } = New List<TraderRecord>()
    }
