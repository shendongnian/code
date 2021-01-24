    private void button1_Clicked(object sender, EventArgs e)
    {
        if (textbox1.text="")
        {
            textbox1.Text = "5";
            textbox2.Text = "10";
        }
        else
        {
              string temp = textbox1.Text;
              textbox1.Text = textbox2.Text;
              textbox2.Text = temp;
        }
}
