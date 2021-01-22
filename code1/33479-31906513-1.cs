    using System.Windows.Forms.Design;
    
    [Designer(typeof(ControlDesigner))]
    public class SpecificDataGridView : DataGridView
    {
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewColumnCollection Columns
        {
            get { return base.Columns; }
        }
         
        ...etc...
    }
