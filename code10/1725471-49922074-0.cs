     var headBlock=new TransformManyBlock<int,SomeRow>(_=>
        {
            using(var con=new SqlConnection(..whatever))
            {
                var items=con.ExecuteQuery(theQuery);
                return itmes;
            }
        });
     var secondBlock = new ActionBlock<SomeRow>(row=>DoSomething(row), 
                              new ExecutionDatalfowBlockOptions{MaxDegreeOfParalelism=10});
     headBlock.LinkTo(secondBlock,new DataFlowLinkOptions{PropagateCompletion=true});
     var headObs=headBlock.AsObserver();
     Observable.Interval(TimeSpan.FromMinutes(1)).Subscribe(headObs);
