    void ConsumersInParalell()
    {
        //This assumes the method signature of DoSomthing is one of the following:
        //    Action<MagicalObject>
        //    Action<MagicalObject, ParallelLoopState>
        //    Action<MagicalObject, ParallelLoopState, long>
        Paralell.ForEach(this.Collection.GetConsumingEnumerable(), DoSomthing);
    }
