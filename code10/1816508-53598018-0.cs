    private asyc void BtnUpdateUser_Click(object sender, EventArgs e) {
        UserRepository userRepository = new UserRepository();
        var user = userRepository.GetAllUsers().Where(w => w.UserId == 1).FirstOrDefault();
        user.UserName = "UpdateUserName";
        var result = await  userRepository.UpdateUserAsync(user.Id, user);
    }
