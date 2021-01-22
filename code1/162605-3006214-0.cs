    private void buttonON()
    {
        // Magic here
    }
    private void buttonOFF()
    {
        // Magic here
    }
    protected void button_click(object sender, EventArgs e)
    {
        if ( button.Text == "ON" )
        {
            button.Text = "OFF";
            this.buttonOFF();
        }
        else
        {
            button.Text = "ON";
            this.buttonON();
        }
    }
