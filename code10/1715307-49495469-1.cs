    Task<string[]> t = new Task<string[]>(() => grabber.grab(link));
    //   ^^^^^^^^  also defining what the t.Result should contain    
    var x = await Task.WhenAny(t, Task.Delay(TimeSpan.FromSeconds(3)));
    if (x == t){ // make sure that Task.WhenAny returned the t Task
    {
        string[] result = t.Result; // get t's Result, not x
        foreach (string item in result)
        {
            list.Add(item);
        }
    }
