    public partial class Blog : UserControl { 
    
        protected override void AddedControl(Control control, int index) {
          base.AddedControl(control, index);
          
          Commenting commentingControl = control as Commenting;
          if (commentingControl == null) return;
          commentingControl.OnComment_SendEmail += new Commenting_OnSendMail(Blog_Comment_OnSendEmail);
        }
    }
