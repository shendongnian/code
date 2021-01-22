    private ToolStripItemCommand fooCommand;
    
    private void wireUpCommands()
    {
        fooCommand = new HelloWorldCommand();
        fooCommand.RegisterControl(fooToolStripMenuItem, "Click");
        fooCommand.RegisterControl(fooToolStripButton, "Click");            
    }
    
    private void toggleEnabledClicked(object sender, EventArgs e)
    {
        fooCommand.Enabled = !fooCommand.Enabled;
    }
    
    private void toggleVisibleClicked(object sender, EventArgs e)
    {
        fooCommand.Visible = !fooCommand.Visible;
    }
