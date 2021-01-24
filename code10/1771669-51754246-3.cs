    public IActionResult Test(string id)
    {
        var user = context.Users.First(x => x.Id.ToString() == id);
        var message = "abc";
        // The generic types will be inferred here so they're not necessary
        // but I've added them for clarity in the example.
        var viewModel = Tuple.Create<User, string>(user, message);
        return View("Edit", viewModel);
    }
