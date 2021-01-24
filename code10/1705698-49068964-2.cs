        var toWait = new List<Task>();
        List<X> bunchOfSubBunchsOfThingsTodo = getBunchOfSubBunchsOfThingsTodo();     
        foreach (var subBunchOfThingsToDo in bunchOfSubBunchsOfThingsTodo)
        {
            int idSubBunchOfThingsToDo = subBunchOfThingsToDo.ThingsToDo.FirstOrDefault().IdSubBunchOfThingsToDo;
        
            var parent = Task.Factory.StartNew(() =>
            {
                Parallel.ForEach(subBunchOfThingsToDo.ThingsToDo,
                    thingToDo =>
                    {
                            //Do some stuff with thingToDo... Here I call several bussines methods
                    });
            });
        
            //parent.Wait();
            var handle = parent.ContinueWith((x) =>
            {
                DoSomethingAfterEveryThingToDoOfThisSubBunchOfThingsAreDone(idSubBunchOfThingsToDo);
            })
            .Start();
            toWait.Add(handle);
        }
        Task.WhenAll(toWait);
            
