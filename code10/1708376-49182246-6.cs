    [Binding]
    public class MyTransformations
    {
        [StepArgumentTransformation]
        public MenuItem[] ToMenuItems(Table table)
        {
            return table.Rows.Select(row => new MenuItem(row[0])).ToArray();
        }        
    }
