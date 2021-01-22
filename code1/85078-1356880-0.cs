    [Designer(typeof(myControlDesigner))] 
    public class MyPanel : UserControl
    {
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelMain;
        ...
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Panel InnerPanel
        {
            get { return panelMain; }
            set { panelMain = value; }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TableLayoutPanel InnerTableLayout
        {
            get { return tableLayoutPanel1; }
            set { tableLayoutPanel1 = value; }
        }
    }
