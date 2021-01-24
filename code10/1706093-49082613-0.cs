    [HttpPost]
    public async Task<IActionResult> YourMethod()
    {
        using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
        {  
            var token = await reader.ReadToEndAsync(); // returns raw data which is sent in body
        }
        // your code here
    }
