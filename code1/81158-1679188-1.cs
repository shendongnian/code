[KnownType(typeof(ContentItem))]
[DataContract(Name = "PageableList_Of_{0}")]
public class PageableResults&lt;T&gt; : EntityCollectionWorkaround&lt;T&gt;
{   
    [DataMember]
    public int TotalRows { get; set; }
}
