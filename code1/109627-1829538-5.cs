    private void control1_SomeEvent(object sender, EventArgs e)
    {
        MyOption option = GetOptionFromDropDown();
        DoSomething(option.ID);
    }
    private void control2_SomeEvent(object sender, EventArgs e)
    {
        MyOption option = GetOptionFromDropDown();
        DoSomethingElse(option.Value);
    }
