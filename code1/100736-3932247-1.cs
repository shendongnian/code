class ServiceProxy : ClientBase&lt;IService&gt;, IService
 {
  public List<ContentItem> GetContentList()
  {
   return Channel.GetContentList();
  }
 }
