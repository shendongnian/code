    // where you create the looper and call StartLooping()
    private void Start()
    {
        var looper = new PromiseLooper<int>(GenerateRandomInt, IsNotFive);
        looper.StartLooping(0).Then(
            () => Console.WriteLine("Loop complete!"),
            e => Console.WriteLine($"Loop error! {e}"));
    }
    
    // the predicate that decides the end of the loop
    private bool IsNotFive(int x)
    {
        return x != 5;
    }
    
    // the method you want to loop!
    private IPromise<int> GenerateRandomInt()
    {
        var promise = new Promise<int>();
        //this could be any async time consuming call
        // that resolves the promise with the outcome
        LeanTween.delayedCall(1,
            () => promise.Resolve(Random.Range(0, 10))
        );
        return promise;
    }
