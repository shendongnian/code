    foreach (Control c in this.Controls)
    {
        if (c is Button)
        {
            Button button = c as Button;
            // Do something with 'button' here
        }
        else if (c is Label)
        {
            Label label = c as Label;
            // Do something with 'label' here
        }
    }
