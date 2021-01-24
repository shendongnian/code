    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    namespace DemoControls
    {
        [ToolboxItem(true)]
        public class SimpleButton : Button
        {
            public SimpleButton()
            {
                Font = new Font("Segoe UI", 10, FontStyle.Regular);
                Height = 50;
                BackColor = DefaultBackColor;
            }
        }
    }
