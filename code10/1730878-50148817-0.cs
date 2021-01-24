    var user = await graphClient.Users.Request().GetAsync();
    var users = user.Select(u => { u.Surname = u.Surname ?? "blank"; return u; });
    return JsonConvert.SerializeObject(users
           .Where(u => u.surname.ToUpper().StartsWith(textValue.ToUpper()),
             Formatting.Indented ));
