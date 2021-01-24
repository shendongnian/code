if (!userList.Exists(y => y.UserName == username) && !userList.Exists(y => y.Password == pass))
{
    TempData["Message"] = "Wrong username or password.";
    return RedirectToAction("Index");
}
Here you are validating that *there exists a specific username in the database* and that *there exists a specific password in the database*. This means that you may authenticate a user with someone else's password!
I suggest you first find the correct user and **then** compare the password.
var user = userList.SingleOrDefault(y => y.UserName == username);
if (user != null)
{
    if (user.Password != null && user.Password.Equals(pass))
    {
        // ok
    }
    else
    {
        TempData["Message"] = "Wrong username or password.";
        return RedirectToAction("Index");
    }
}
else
{
    TempData["Message"] = "Wrong username or password.";
    return RedirectToAction("Index");
}
About future password storage
=========================
Secondly, you are not hashing user passwords. This is a classic security issue.  See [Salted Password Hashing - Doing it Right](https://crackstation.net/hashing-security.htm).
About authentication
=========================
In general, authenticating users is done with peers-validated libraries that are known to have zero security flaws. 
