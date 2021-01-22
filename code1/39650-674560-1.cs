    using System.Windows.Forms;
    private void txtInput_KeyUp(object sender, KeyEventArgs e)
    {
        if(e.KeyCode == Keys.Enter)
            DoSomething();
    }
