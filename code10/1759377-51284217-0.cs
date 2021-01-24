    private SecondViewModel()
    {
    }
    public static async Task<SecondViewModel> CreateAsync(MyType parameter)
    {
        var result = new SecondViewModel();
        result.SomeData = await getDataFromDatabaseAsync(parameter);
        return result;
    }
