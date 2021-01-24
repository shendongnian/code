    public class KnowledgebaseResponse
    {
    	public List<KnowledgebaseItem> QnaDocuments { get; set; }
    }
    
    public class KnowledgebaseItem
    {
    	public int Id { get; set; }
    	public string Answer { get; set; }
    	public string Source { get; set; }
    	public List<string> Questions { get; set; }
    	public List<KeyValuePair<string, string>> MetaData { get; set; }
    }
