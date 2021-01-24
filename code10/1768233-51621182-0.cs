    public async Task<IActionResult> SaveStudent([FromBody] Student stu)
    {
    if (!context.ModelState.IsValid)
                {
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
    ...
    }
