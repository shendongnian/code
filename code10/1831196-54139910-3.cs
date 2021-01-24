    using System.ComponentModel;
    using System.Windows.Forms;
 
    [DesignerCategory("code")]
    public class DrawingPanel : Panel
    {
        public DrawingPanel()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint |
                          ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();
        }
    }
