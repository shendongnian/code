    public interface ICommented
    {
        string Comment { get; set; }
    }
    public class MyClass : ICommented
    {
        public string Comment { get; set; }
    }
    public partial class CommentEntry : Form
    {
        public CommentEntry(Control pControl, ICommented commented)
        {
            InitializeComponent();
            control = pControl;
            // ***** Need a way for this to store the reference not the value. *****
            _commented = commented;
        }
        private ICommented _commented;
        private void CommentEntry_Closing(object sender, CancelEventArgs e)
        {
            _commented.Comment = tbCommentText.Text.Trim();
        }
    }
