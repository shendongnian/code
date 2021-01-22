    [ComVisible(true)]
    public partial class Form1 : Form
    {
        ......
        webBrowser.ObjectForScripting = this;
        ......
        public void CallMeInForm(string something)
        {
            MessageBox.Show("Silverlight said: " + something);
        }
    }
