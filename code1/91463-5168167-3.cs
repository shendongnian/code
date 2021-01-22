    public enum RegisterResult
    {
      Success,
      BadUsernamePassword,
      PasswordTooShort
    }
    RegisterResult result = Register("someone", "password");
    switch(result)
    {
      case(RegisterResult.Success):
        // success
        break;
      case(RegisterResult.BadUsernamePassword):
        // failed
        break;
      case(RegisterResult.PasswordTooShort):
        // failed
        break;
    }
