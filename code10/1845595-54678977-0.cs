    ...
    private void button1_Click(object sender, EventArgs e)
    {
        var value = new Class1(textbox1.Text);
    }
    ...
    public class Class1
    {
        public Class1(string textboxText) => tv = textboxText;
        string tv;
    }
