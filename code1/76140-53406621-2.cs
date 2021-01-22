    public partial class frmFind: Form
    {
        public frmFind(object arguments)
        {
    
            InitializeComponent();
    
            var args = arguments.CastTo(new { Title = "", Type = typeof(Nullable) });
    
            this.Text = args.Title;
            
            ...
        }
        ...
    }
