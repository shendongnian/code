    public partial class YourForm : Form
    {
        // Make sure to mark this variable as volatile.
        private volatile bool m_Checked;
        private void YourForm_Load(object sender, EventArgs e)
        {
            m_Checked = YourCheckbox.Checked;
            var thread = new Thread(
                () =>
                {
                    while (true)
                    {
                      // This read will come from main memory since the
                      // variable is marked as volatile.
                      bool value = m_Checked;
                    }
                });
            thread.Start();
        }
        private void YourCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            // This write will be committed to main memory since the
            // variable is marked as volatile.
            m_Checked = YourCheckbox.Checked;
        }
    }
