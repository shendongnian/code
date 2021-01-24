    public partial class Form1 : Form
    {
     ...
        private readonly SynchronizationContext _synchronizationContext;
        public Form1()
        {
	       InitializeComponent();
	       _synchronizationContext = SynchronizationContext.Current;
        }
