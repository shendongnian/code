    public EventHandler<EventArgs> Button1Clicked;
    private void button1_Click(object sender, EventArgs e)
    {
        if (this.Button1Clicked != null)
        {
            this.Button1Clicked(sender, e);
        }
    }
