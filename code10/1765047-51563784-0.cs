    [TestFixture]
    public class DataFlowTests
    {
        [Test]
        public async Task BufferEmptiesBeforePropaghatingCompletion()
        {
            var cts = new CancellationTokenSource();
            var buffer = new BufferBlock<int>(new DataflowBlockOptions() { BoundedCapacity = 200, CancellationToken = cts.Token });
            var action = new ActionBlock<int>(x => Task.Delay(100), new ExecutionDataflowBlockOptions() { BoundedCapacity = 5 });
            buffer.LinkTo(action, new DataflowLinkOptions() { PropagateCompletion = false});
            
            foreach (var data in Enumerable.Range(0, 20))
            {
                if (data > 10) break;
                await buffer.SendAsync(data);
            }
            cts.Cancel();
            //action.Complete();
            await action.Completion;
            Console.WriteLine(buffer.Completion.Status);
            Console.WriteLine(action.Completion.Status);
        }
    }
