    public class YourObject{
       public List<OtherObject> Others { get; set; }
    }
    public class OtherObject{
       public void DoIt(){}
    }
    var theList = new List<YourObject>();
    theList.ForEach(yo => yo.Others.ForEach(oo => oo.DoIt()));
