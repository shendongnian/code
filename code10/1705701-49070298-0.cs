    static async void ProcessThingsToDo(IEnumerable<ThingToDo> bunchOfThingsToDo)
    {
        IEnumerable<Task> GetSubTasks(ThingToDo thing) 
            => thing.SubBunchOfThingsToDo.Select( async subThing => await Task.Run(subThing));
        var tasks = bunchOfThingsToDo
            .Select(async thing => await Task.WhenAll(GetSubTasks(thing)));
        await Task.WhenAll(tasks);
    }
