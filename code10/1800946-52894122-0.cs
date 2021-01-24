    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\image\\Programcilar", "controlller.jpg");
    if(System.IO.File.Exists(path))
    {
        System.IO.File.Delete(path);
    }
