    public IActionResult Products(int id)
    {
        var pivm = new ProductInfoViewModel {SelectedId = id};
        pivm= UpdateModelFromSelectedId(pivm);
        return View(pivm);
    }
