class DirectorySource&lt;T&gt;: IDirectorySource&lt;T&gt;  {   
  public DirectorySource(ISearcher&lt;T&gt; searcher) {
    Searcher = searcher;   
  }   
  public IList&lt;T&gt; ToList()    {
    string filter = "...";
    return Searcher.FindAll(filter);   
  } 
}     
class GroupSearcher: ISearcher&lt;Group&gt; {
  public IList&lt;Group&gt; FindAll(string filter)    {
    entries = ...
    var entities = new List&lt;Group&gt;();
    foreach (var entry in entries) 
      entities.Add(new Group(entry.GetDirectoryEntry());
    return entities;   
  } 
}
