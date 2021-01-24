    @{
        string title = "This is the title";
        var names = "";
        var emails = "";
        if (IsPost)
        {
            var name = Request["name"];
            var email = Request["email"];
            string message = Request["message"];
            names = name;
            emails = email;
        }
    }
