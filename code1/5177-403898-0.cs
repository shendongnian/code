    using System.Windows.Forms;
     
    namespace HideWindows
    {
        public class HideForm : Form
        {
            public HideForm()
            {
                Opacity = 0;
                ShowInTaskbar = false;
            }
     
            public new void Show()
            {
                Opacity = 100;
                ShowInTaskbar = true;
     
                Show(this);
            }
        }
    }
