    ToolStripDropDownButton buttonStates = new ToolStripDropDownButton();
    buttonStates.DropDown.Closing += new ToolStripDropDownClosingEventHandler(buttonStatesDropDown_Closing);
    private void buttonStatesDropDown_Closing(object sender, ToolStripDropDownClosingEventArgs e)
    {
        e.Cancel = true;
    }
