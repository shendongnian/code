    using System.Drawing;
    using System.Windows.Forms;
    public class MyPanel : Panel
    {
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
    }
