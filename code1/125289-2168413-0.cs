    foreach(Button b in MyForm.Controls.OfType<Button>())
    {
        b.Click += Button_Click;
    }
    
---
    
    void Button_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;
    }
