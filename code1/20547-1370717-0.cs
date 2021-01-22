    cbx_Example.Enter += cbx_Example_Enter;
    cbx_Example.SelectionChangeCommitted += cbx_Example_SelectionChangeCommitted;
    ...
   
    private int prevExampleIndex = 0;
    private void cbx_Example_Enter(object sender, EventArgs e)
    {
        prevExampleIndex = cbx_Example.SelectedIndex;
    }
        
    private void cbx_Example_SelectionChangeCommitted(object sender, EventArgs e)
    {
        // some custom flag to determine Edit mode
        if (mode == FormModes.EDIT) 
        {
            cbx_Example.SelectedIndex = prevExampleIndex;
        }
    }
