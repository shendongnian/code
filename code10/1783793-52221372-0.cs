    [Fact]
    public void Show_Valid()
    {
        var controller = new BankIntegrationController { Valid = true };
        // Any other set up here...
        var result = controller.Show();
        // Assertions about the result
    }
    [Fact]
    public void Show_Invalid()
    {
        var controller = new BankIntegrationController { Valid = false };
        // Any other set up here...
        var result = controller.Show();
        // Assertions about the result
    }
