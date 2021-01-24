    //This Gets all textboxes, in your window actually named: form;
    //List<TextBox> should also work!
    IEnumerable<TextBox> textBoxes = this.Controls.OfType<TextBox>(); 
    foreach (TextBox textBox in textBoxes)
    {
        if(string.IsNullOrEmpty(textBox.Text)
        {
             //DO SOMETHING IF IT's NULL (or just "")
        }
        else
        {
             //DO SOMETHING ELSE...
        }
    }
