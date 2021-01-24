    private void VisibleOn1Or2(State state, Control control)
    {
       control.Visible = (state.Status == "1" || state.Status == "2");
    }
    private void VisibleOn1(State state, Control control)
    {
       control.Visible = (state.Status == "1");
    }
    //Etc
