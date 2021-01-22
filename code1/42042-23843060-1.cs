    public partial class MyForm : Form
    {
        private readonly SynchronizationContext _context;
        public MyForm()
        {
            _context = SynchronizationContext.Current
            ...
        }
        private MethodOnOtherThread()
        {
             ...
             _context.Post(status => someLabel.Text = newText,null);
        }
    }
