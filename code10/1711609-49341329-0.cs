    [AuthGet("test1", "role1")]
    public async Task<object> Test1()
    {
        return await Test(1);
    }
    
    [AuthGet("test2", "role2")]
    public async Task<IActionResult> Test2()
    {
        return await Test(2);
    }
    
    private async Task<object> Test(int testRoute)
    {
        if (testRoute == 1)
        {
            //do something
        }
        else
        {
            // do somthing else
        }
    }
