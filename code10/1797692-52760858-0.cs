    public async static Task<int> MyAsyncMethod()
    {
       await Task.Delay(100);
       return 100;
    }
    //Task.Delay(5000).RunSynchronously();                        // bang, task with NO delegate
    //Task.Run(() => Thread.Sleep(5000)).RunSynchronously();     // bang, task already started
    // MyAsyncMethod().RunSynchronously();                      // bang, task is completed
    var t = new Task(() => Thread.Sleep(5000));
    t.RunSynchronously();                                     // works
