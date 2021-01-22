    //using System.Linq;
    //using System.Reactive.Linq;
    //using System.Reactive.Threading.Tasks;
    var observableBatches = anAnumerable.ToObservable().Buffer(size);
    
    var batches = aList.ToObservable().Buffer(size).ToList().ToTask().GetAwaiter().GetResult();
    
