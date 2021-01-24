    public class CompleteInfos
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    
    	public string prop1 { get; set; }
    	public string prop2 { get; set; }
    }
    public class Info{
    	public int Id { get; set; }
    	public string Name { get; set; }
    }
    
    List<CompleteInfos> Table = new List<CompleteInfos>(); 
    List<Info> infos = new List<Info>(); // List contains your namse and ids
    foreach(var info in infos)
    {
    	List<CompleteInfos> selectedInfo = Table.Where(x => x.Id == info.Id || x.Name == info.Name).ToList();
        //selectedInfo  is the list in which you can find all item that have your desired id and name
    }
