    void digitButton_Click(object sender, EventArgs e)
    {
        Button ButtonThatWasPushed = (Button)sender;
        string ButtonText = ButtonThatWasPushed.Text; //the button's Text
        //do something
        //If you store the button's numeric value in it's Tag property
        //things become even easier.
        int ButtonValue = (int)ButtonThatWasPushed.Tag;
    }
