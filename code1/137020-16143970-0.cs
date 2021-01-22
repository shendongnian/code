    //Property class
    [DataContract()]
    public class Info
    {
    [DataMember(Name = "created_date")]
    public string CreateDate;
    }
    
    //Controller
    var date = from p in dbContext.Person select p;
    CreateDate = Convert.ToDateTime(p.create_date).ToString("yyyy-MM-dd");
