using System.Collections.ObjectModel;
public class EmailCollection : Collection&lt;Email>
{
    public int MaximumAttachments { get; set; }
    protected override void InsertItem(int index, Email item)
    {
        if (Count == MaximumAttachments)
        {
            ... throw error
        }
     
        // do actual insert
        base.InsertItem(index, item)
    }
}
