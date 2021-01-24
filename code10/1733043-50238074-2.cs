    var tasks = new List<Task<List<Animal>>>
    {
      GetGiraffesAsync().GeneralizeTask<Animal, Giraffe>(),
      GetTigersAsync().GeneralizeTask<Animal, Tiger>()
    };
