    [TestFixture]
    public class BlockTester
    {
        private int count;
        [Test]
        public async Task Test()
        {
            var inputBlock = BuildPipeline();
            var max = 1000;
            foreach (var input in Enumerable.Range(1, max))
            {
                inputBlock.Post(input);
            }
            inputBlock.Complete();
            //No reference to block b
            //so we can't await b completion
            //instead we'll just wait a second since
            //the block should finish nearly immediately
            await Task.Delay(TimeSpan.FromSeconds(1));
            Assert.AreEqual(max, count);
        }
        public ITargetBlock<int> BuildPipeline()
        {
            var a = new TransformBlock<int, int>(x => x);
            var b = new ActionBlock<int>(x => count = x);
            a.LinkTo(b, new DataflowLinkOptions() {PropagateCompletion = true});
            return a;
        }
    }
