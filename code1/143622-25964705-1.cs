     public partial class FormGDI : Form
        {
            
            ReSize resize = new ReSize();     // ReSize Class "/\" To Help Resize Form <None Style>
           
    
            public FormGDI()
            {
                InitializeComponent();
                this.SetStyle(ControlStyles.ResizeRedraw, true);
    
            }
    
          
            private const int cGrip = 16;      // Grip size
            private const int cCaption = 32;   // Caption bar height;
    
            protected override void OnPaint(PaintEventArgs e)
            {
                //this if you want to draw   (if)
    
                Color theColor = Color.FromArgb(10, 20, 20, 20);
                theColor = Color.DarkBlue;
                int BORDER_SIZE = 4;
                ControlPaint.DrawBorder(e.Graphics, ClientRectangle,
                                             theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,
                                             theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,
                                             theColor, BORDER_SIZE, ButtonBorderStyle.Dashed,
                                             theColor, BORDER_SIZE, ButtonBorderStyle.Dashed);
    
               
                Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
                ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
                rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
                e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
                
    
               
                base.OnPaint(e);
            }
    
    
            //set MinimumSize to Form
            public override Size MinimumSize
            {
                get
                {
                    return base.MinimumSize;
                }
                set
                {
                    base.MinimumSize = new Size(179, 51); 
                }
            }
    
            //
            //override  WndProc  
            //
            protected override void WndProc(ref Message m)
            {
                //****************************************************************************
                
                int x = (int)(m.LParam.ToInt64() & 0xFFFF);               //get x mouse position
                int y = (int)((m.LParam.ToInt64() & 0xFFFF0000) >> 16);   //get y mouse position  you can gave (x,y) it from "MouseEventArgs" too
                Point pt = PointToClient(new Point(x, y));
    
                if (m.Msg == 0x84)
                {
                    switch (resize.getMosuePosition(pt, this))
                    {
                        case "l": m.Result = (IntPtr)10; return;  // the Mouse on Left Form
                        case "r": m.Result = (IntPtr)11; return;  // the Mouse on Right Form
                        case "a": m.Result = (IntPtr)12; return;
                        case "la": m.Result = (IntPtr)13; return;
                        case "ra": m.Result = (IntPtr)14; return;
                        case "u": m.Result = (IntPtr)15; return;
                        case "lu": m.Result = (IntPtr)16; return;
                        case "ru": m.Result = (IntPtr)17; return; // the Mouse on Right_Under Form
                        case "": m.Result = pt.Y < 32 /*mouse on title Bar*/ ? (IntPtr)2 : (IntPtr)1; return;  
                             
                    }
                }
               
                  base.WndProc(ref m);
    
            }
    
        }
