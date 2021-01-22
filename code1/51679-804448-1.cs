        public class MousePreviewForm : Form
        {
          protected override void OnClosed(EventArgs e)
          {
             UnhookControl(this as Control);
             base.OnClosed(e);
          }
    
          protected override void OnLoad(EventArgs e)
          {
             base.OnLoad(e);
    
             HookControl(this as Control);
          }
    
          private void HookControl(Control controlToHook)
          {
             controlToHook.MouseClick += AllControlsMouseClick;
             foreach (Control ctl in controlToHook.Controls)
             {
                HookControl(ctl);
             }      
          }
    
          private void UnhookControl(Control controlToUnhook)
          {
             controlToUnhook.MouseClick -= AllControlsMouseClick;
             foreach (Control ctl in controlToUnhook.Controls)
             {
                UnhookControl(ctl);
             }
          }
    
          void AllControlsMouseClick(object sender, MouseEventArgs e)
          {
             //do clever stuff here...
             throw new NotImplementedException();
          }
       }
