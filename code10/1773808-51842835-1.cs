    public IActionResult Get()
    {
        using (StreamReader reader = new StreamReader("data/test.json", System.Text.Encoding.UTF8))
        {
            string json = reader.ReadToEnd();
            return Content(json, "application/json");
        }
    }
