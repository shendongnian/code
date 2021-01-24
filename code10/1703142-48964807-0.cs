    public ActionResult Index(int id = 1)
    {
        var cars = repositoryManager.CarRepository.GetAll().Skip(id).Take(1).ToList();
        return View(cars);
    }
