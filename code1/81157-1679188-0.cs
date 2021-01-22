[KnownType(typeof(ContentItem))]
[DataContract(Name = "PageableList_Of_{0}")]
public class PageableResults&lt;T&gt;
{
    [DataMember]
    public IList&lt;T&gt; Items { get; set; }
    [DataMember]
    public int TotalRows { get; set; }
}
[OperationContract]
PageableResults<ContentItem> ListCI();
