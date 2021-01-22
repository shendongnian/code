    // UserService uses UserRepository internally + any additional business logic.
    var service = new UserService();
    var user = service.GetById(32);
    user.ResetPassword();
    user.OtherBusinessLogic("test");
    user.FirstName = "Bob";
    service.Save(user);
