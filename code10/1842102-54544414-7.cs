    public IActionResult Download()
    {
        var download = Serialize(_context.Users, _options.Value.SerializerSettings);
        return File(download , "application/json", "file.json");
    }
