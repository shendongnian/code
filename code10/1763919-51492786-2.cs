    public async void OnButton3_Clicked(object sender, ...)
    {   
        // start several tasks. Don't await yet:
        var task1 = TestAsync(1);
        var task2 = TestAsync(2);
        var task3 = TestAsync(3);
        DoSomethingElse();
        // if here I need the results of all three tasks:
        var myTasks = new Task[] {task1, task2, task3};
        await Task.WhenAll(myTasks);
    }
