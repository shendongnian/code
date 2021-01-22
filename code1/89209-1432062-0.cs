    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult MyProfile(int id, string password2)
    {
        MSD_AIDS_Images_Data.LINQRepositories.User user = <LINQ query to load user by id>;
        UpdateModel(user); // updates the model with form values
        userService.SaveChanges();
    }
