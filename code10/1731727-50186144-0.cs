    [HttpGet]
    public IEnumerable<string> Get()
    {
        Task task = new Task(() =>
        {
            for (int i = 0; i < 5000; i++)
            {
                System.Threading.Thread.Sleep(2000);
                Debug.WriteLine("Still running here...");
            }
        });
        task.Start();
        return new string[] { "value1", "value2" };
    }
