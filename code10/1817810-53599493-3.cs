    [HttpGet]
    public IActionResult AddDogFriend(AddDogFriendViewModel model)
    {
        model.Dog = new Dog();
        model.Dog = dogFaceDbContext.Dogs.Include("DogFriends").Where(d => d.FirstName == model.DogFriendSearchInput).FirstOrDefault();
        return View(model);
    }
