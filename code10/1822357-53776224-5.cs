    public void TooglePasswordVisablilty()
    {
        bool isCurrentlyPassword = passwordInput.inputType == UIInput.InputType.Password;
        passwordInput.inputType = isCurrentlyPassword ? UIInput.InputType.Standard : UIInput.InputType.Password;
        passwordInput.UpdateLabel();
    }
