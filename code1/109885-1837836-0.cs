    ...
    DataGridTextColumn dgtc2 = new ExtendedDataGridTextColumn(); 
    dgtc2.Header = "Zip Code"; 
    ...
    public class ExtendedDataGridTextColumn : DataGridTextColumn 
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock element = (TextBlock)base.GenerateElement(cell, dataItem);
            element.Text = ((Customer)dataItem).ZipCode + "-0000";
            return element;
        }
    }
