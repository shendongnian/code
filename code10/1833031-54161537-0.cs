    public async Task<IEnumerable<int>> Test(Action<something> action)
    {
       foreach (int item in await MethodThatReturnsObjectsAsync())
       {
          action(item);
       }
       ...
       return ...
    }
    private static async Task<IEnumerable<int>> MethodThatReturnsObjectsAsync()
    {
       throw new NotImplementedException();
    }
