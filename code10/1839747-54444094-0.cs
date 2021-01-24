    //Text changed event for textBox1
    private void textBox1_TextChanged(object sender, RoutedEventArgs e)
    {
        //If null set to empty
        textBox1.Text = textBox1.Text ?? "";
        SetMaskedTextbox();
        
    }
    
    //Text changed event for textBox2
    private void textBox2_TextChanged(object sender, RoutedEventArgs e)
    {
        //If null set to empty
        textBox2.Text = textBox2.Text ?? "";
        SetMaskedTextbox();
    }
    private void SetMaskedTextbox()
    {
        //Just concatenate the textbox values with the "/" and set it to the masked textbox .Text
        maskedTextbox.Text = textBox1.Text + "/" + textBox2.Text;
    }
