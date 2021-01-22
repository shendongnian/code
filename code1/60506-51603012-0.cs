     public partial class Form1: Form
     {
        private void Form1_Load(object sender, EventArgs e)
        {
            ...
            forceBindTabs(tabControl1);
        }
        private void forceBindTabs(TabControl ctl)
        {
            ctl.SuspendLayout();
            foreach (TabPage tab in ctl.TabPages)
                tab.Visible = true;
            ctl.ResumeLayout();
        }
     }
