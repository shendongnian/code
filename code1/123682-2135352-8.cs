    var syn = new ThreadSafeClass.Synchronizer();
    syn.Execute(inst => { 
        inst.PropertyA = 2.0;
        inst.PropertyB = 2.0;
        inst.PropertyC = 2.0;
    });
    var a = syn.Execute<double>(inst => {
        return inst.PropertyA + inst.PropertyB;
    });
