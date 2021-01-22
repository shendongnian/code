        using System;
        using System.Drawing;
        using System.Windows.Forms;
        namespace testFocusableControl
        {
            // Visual Studio 2010 RC1 : Tested against FrameWork 3.5 Full (not 'Client)
            public class Control1 : Control
            {
                public Control1()
                {
                    // not necessary
                    // SetStyle(ControlStyles.UserPaint, true);
                    // not necessary, but does not interfere
                    // SetStyle(ControlStyles.Selectable, true); 
                    SetStyle(ControlStyles.UserMouse, true);
                    // must use these to Invalidate !
                    this.GotFocus += new EventHandler(Control1_GotFocus);
                    this.LostFocus += new EventHandler(Control1_LostFocus); 
                }
                // no effect
                //protected virtual void OnLostFocus(EventArgs e)
                //{
                //    //this.Invalidate();
                //    //base.OnLostFocus(e);
                //}
                // no effect
                //protected virtual void OnGotFocus(EventArgs e)
                //{
                //    //this.Invalidate();
                //    //base.OnGotFocus(e);
                //}
                public void Control1_GotFocus(object sender, EventArgs e)
                {
                    this.Invalidate();
                }
                public void Control1_LostFocus(object sender, EventArgs e)
                {
                    this.Invalidate();
                }
                protected override void OnPaint(PaintEventArgs e)
                {
                    if(this.Focused)
                    {
                        ControlPaint.DrawFocusRectangle(e.Graphics, this.ClientRectangle, Color.Red, Color.Blue);
                    }
                }
            }
        }
