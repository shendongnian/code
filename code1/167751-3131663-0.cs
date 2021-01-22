    using System.Linq;
    
    GridView1.Columns
        .OfType<DataControlField>()
        .Where(c => GridView1.Columns.IndexOf(c) > 1)
        .ToList()
        .ForEach(c => c.Visible = false);
