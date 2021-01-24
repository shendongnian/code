    if (!Regex.IsMatch(username, @"^[A-Za-z][A-Za-z0-9_#\$]$")) {
      // username is invalid
    }
    if (string.IsNullOrEmpty(newPassword) || newPassword.Any(c => char.IsControl(c))) {
      // password is invalid
    }
    using (var context = _dbContextFactory.CreateContext()) {
      await context.Database.ExecuteSqlCommandAsync(
        $"ALTER USER {username} IDENTIFIED BY \"{newPassword.Replace("\"", "\"\"")}\"");
    }
