    var user = await graphClient.Users.Request().GetAsync();
    var user2 = user
       .Select(u => { u.Surname = u.Surname ?? "blank"; return u; })
       .Where(u => u.surname.ToUpper().StartsWith(textValue.ToUpper())
       ;
    return JsonConvert.SerializeObject(user2, Formatting.Indented ));
