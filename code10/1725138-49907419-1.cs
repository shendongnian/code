    public class Machine
    {
    public int Id { get; set; }
    [Index("NameClusteredIndex", IsClustered = true)]
    public string Name { get; set; }
    public SelectListItem ToSelectListItem()
    {
        return new SelectListItem
        {
            Value = Id.ToString(),
            Text = Name
        };
    }
 }
