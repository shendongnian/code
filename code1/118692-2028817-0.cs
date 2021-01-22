    public int function(int a, int b, ref string text)
    {
        //do something
        if (a + b > 50)
        {
            text = "Omg its bigger than 50!";
        }
        return (a + b);
    }
    
    string text = TextBox.Text;
    function(ref text);
    TextBox.Text = text;
