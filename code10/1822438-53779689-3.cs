    public partial class Form1 : Form
    {
    public RichTextBox RichText => richLogWindow;
    private void button1_Click_1(object sender, EventArgs e)
    {
       var someclass = new SomeClass();
       someclass.SomeMethod(this);
    }
    }
