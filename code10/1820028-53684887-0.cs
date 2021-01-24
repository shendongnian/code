    public static void Validate(Form1 myForm)
    {
        foreach (Control control in myForm.Controls)
        {
            string text = control.Text;
            Console.WriteLine(text);
        }
    }
