        [HttpGet]
        public IActionResult AddDogFriend(int dogId)
        {
            var model = new DogViewModel();
            model.Dog = _dogFaceDbContext.Dogs.First(x => x.Id == dogId);
           
            model.Dogs = _dogFaceDbContext.Dogs;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddDogFriend(int dogId, string DogFriendSearchInput, AddDogFriendViewModel model)
        {
            var dog = _dogFaceDbContext.Dogs.First(x => x.Id == dogId);
            var dogFriendToAdd  = _dogFaceDbContext.Dogs.First(x => x.FirstName == DogFriendSearchInput);
           
            dog.DogFriends.Add(new DogFriend { DogId = dog.Id, DogFriendId = dogFriendToAdd.Id });
            
            await _dogFaceDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "DogOwner");
        }
