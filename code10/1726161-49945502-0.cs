    var apiKey = String.Empty; // The id of the user you want to delete
    using (var context = new UserContext())
    {
        User userToDelete = checkIfUserExistsWithApiKeyandReturnUser(apiKey);
        if (userToDelete != null)
        {
            var userLogs = context.Logs.Where(l => l.userAPIKey == apiKey);
            if (userLogs.Any())
            {
                context.Logs.RemoveRange(userLogs);
            }
            context.Users.Attach(userToDelete);
            context.Users.Remove(userToDelete);
            context.SaveChanges();
        }
    }
