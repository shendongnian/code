    using System.ComponentModel;
    using System.Windows.Forms;
    public class MyControl : Control, ISupportInitialize
    {
        public void BeginInit()
        {
        }
        public void EndInit()
        {
            var parent = this.FindForm() as MainForm;
            if (parent != null)
            {
                //Access to MainForm members
            }
        }
    }
