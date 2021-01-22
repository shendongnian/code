        namespace testFocusableControl
        {
            //  VS Studio 2010 RC1 : Tested against FrameWork 3.5 Full (not 'Client)
            public class Control1 : Control
            {
                public Control1()
                {
                    SetStyle(ControlStyles.UserMouse, true);
                }
                protected override void OnLostFocus(EventArgs e)
                {
                    this.Invalidate();
                    base.OnLostFocus(e);
                }
                protected override void OnGotFocus(EventArgs e)
                {
                    this.Invalidate();
                    base.OnGotFocus(e);
                }
                protected override void OnPaint(PaintEventArgs e)
                {
                    if (this.Focused)
                    {
                        ControlPaint.DrawFocusRectangle(e.Graphics, this.ClientRectangle, Color.Red, Color.Blue);
                    }
                    base.OnPaint(e);
                }
            }
        }
