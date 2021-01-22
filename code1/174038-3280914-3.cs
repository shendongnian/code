    Object thisLock = new Object();
    var globalSum = 0;
    System.Threading.Tasks.Parallel.For(0, 100, i => {
        System.Threading.Tasks.Parallel.For(i + 1, 100, () => 0, (num, loopState, subSum) => ++subSum, subSum => { 
            lock(thisLock) { globalSum += subSum; }
        });
    });
    
    Console.WriteLine(globalSum);
