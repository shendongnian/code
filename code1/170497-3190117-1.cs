    public partial class CommentEntry : Form { 
      public CommentEntry(Control pControl, Action<string> reportResult) { 
        InitializeComponent(); 
        control = pControl; 
        // Store the delegate in a local field (no problem here)
        _reportResult = reportResult;    
      } 
 
      private Action<string> _reportResult; 
 
      private void CommentEntry_Closing(object sender, CancelEventArgs e) { 
        // Invoke the delegate to notify the caller about the value
        _reportResult(tbCommentText.Text.Trim()); 
      } 
    } 
