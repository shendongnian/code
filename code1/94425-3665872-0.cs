    public partial class AdvancedContextMenuStrip : ContextMenuStrip
    {
        public AdvancedContextMenuStrip()
        {
            InitializeComponent();
        }
    
        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            if ((keyData & Keys.Alt) == Keys.Alt)
                return true;
    
            return base.ProcessCmdKey(ref m, keyData);
        }
    }
