    public class JoinFlow
    {
        [Test]
        public async Task TestWriteOnceBlock()
        {
            var writeOnceBlockTest = new WriteOnceBlock<int>(i => i);
            var queueBlockTest = new BufferBlock<string>();
            var transformBlockTest = new TransformBlock<string, Tuple<int, string>>(async str => Tuple.Create(await writeOnceBlockTest.ReceiveAsync(), str));
            var actionBlockTest = new ActionBlock<Tuple<int, string>>(tuple => Console.WriteLine($"I received int {tuple.Item1} and string {tuple.Item2}."));
            
            queueBlockTest.LinkTo(transformBlockTest, new DataflowLinkOptions { PropagateCompletion = true });
            transformBlockTest.LinkTo(actionBlockTest, new DataflowLinkOptions { PropagateCompletion = true });
            writeOnceBlockTest.Post(3);
            queueBlockTest.Post("String1");
            queueBlockTest.Post("String2");
            writeOnceBlockTest.Post(4);
            writeOnceBlockTest.Post(5);
            queueBlockTest.Post("String3");
            queueBlockTest.Post("String4");
            queueBlockTest.Complete();
            await actionBlockTest.Completion;
        }
    }
