    public ActionResult<ICollection<Product>> Get()
    {
        public string x = null;
        if(string.IsNullOrEmpty(x))
            return StatusCode(404, "product null");
        else
            return new Product();
    }
