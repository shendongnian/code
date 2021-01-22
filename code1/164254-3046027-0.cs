    public FileContentResult Picture(int id)
    {
        UserRepository r = new UserRepository();   
        return new FileContentResult(r.Single(id).logo.ToArray();, "image/jpeg");
    }
