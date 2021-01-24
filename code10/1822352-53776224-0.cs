    public void ShowPassword()
    {
        if (passwordInput.inputType == UIInput.InputType.Standard) 
        {
            passwordInput.inputType = UIInput.InputType.Password;
            passwordInput.UpdateLabel();
        }
        // after the first statement was executed this will allways be true and will revert the change right ahead
        if (passwordInput.inputType == UIInput.InputType.Password)
        {
            passwordInput.inputType = UIInput.InputType.Standard;
            passwordInput.UpdateLabel();
        }
    }
