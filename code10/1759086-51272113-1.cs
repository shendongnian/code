    public void MyActionMethod()
    {
        var list = Session["Cart"] as IEnumerable<Products>;
        if (list == null) throw new Exception("Cart not found or cannot be enumerated.");
        return View(list.ToList());
    }
