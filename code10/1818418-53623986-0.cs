    //Bad
    class DeleteUserController : Controller { }
    //Better
    class UserController : Controller 
    {
        public async ActionResult Delete(UserDto user) { }
    }
