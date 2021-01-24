    [HttpPost("AddRecord")]
    public async Task<ActionResult<int>> AddRecord(MyModel model)
    {
        if(ModelState.IsValid)
        {
            foreach (var property in model.GetType().GetProperties())
            {
                var attributes = typeof(MyModel).GetProperty(property.Name).GetCustomAttributes(false);
                foreach (object attribute in attributes)
                {
                    if (attribute is MyUpperCaseAttribute myUpperCaseAttribute)
                    {
                        var propetyValue = property.GetValue(model);
                        property.SetValue(model, propetyValue .ToString().ToUpper());
                    }
                }
            }
        }
       return View(model);
    }
