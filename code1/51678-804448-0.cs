       public class MousePreviewForm : Form
       {
          protected override void OnClosed(EventArgs e)
          {
             foreach (var ctl in this.Controls)
             {
                var mouseCtl = ctl as Control;
                if (mouseCtl != null)
                {
                   mouseCtl.MouseClick -= AllControlsMouseClick;
                }
             }
             base.OnClosed(e);
          }
    
          protected override void OnLoad(EventArgs e)
          {
             base.OnLoad(e);
    
             foreach (var ctl in this.Controls)
             {
                var mouseCtl = ctl as Control;
                if (mouseCtl != null)
                {
                   mouseCtl.MouseClick += AllControlsMouseClick;
                }
             }
          }
    
          void AllControlsMouseClick(object sender, MouseEventArgs e)
          {
             //do clever stuff here...
             throw new NotImplementedException();
          }
       }
