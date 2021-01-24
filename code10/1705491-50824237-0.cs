    // A block that remembers every message it receives on two channels, and pairs every message on a channel to every message on the other channel
    public class CartesianProductBlock<T1, T2> : ISourceBlock<Tuple<T1, T2>>
    {
        private TransformManyBlock<T1, Tuple<T1, T2>> left;
        private TransformManyBlock<T2, Tuple<T1, T2>> right;
        private List<T1> leftReceived = new List<T1>();
        private List<T2> rightReceived = new List<T2>();
        private List<ITargetBlock<Tuple<T1, T2>>> targets = new List<ITargetBlock<Tuple<T1, T2>>>();
        private object lockObject = new object();
        public ITargetBlock<T1> Left { get { return left; } }
        public ITargetBlock<T2> Right { get { return right; } }
        public CartesianProductBlock()
        {
            left = new TransformManyBlock<T1, Tuple<T1, T2>>(l =>
            {
                lock (lockObject)
                {
                    leftReceived.Add(l);
                    return rightReceived.Select(r => Tuple.Create(l, r)).ToList();
                }
            });
            right = new TransformManyBlock<T2, Tuple<T1, T2>>(r =>
            {
                lock(lockObject)
                {
                    rightReceived.Add(r);
                    return leftReceived.Select(l => Tuple.Create(l, r)).ToList();
                }
            });
            Task.WhenAll(Left.Completion, Right.Completion).ContinueWith(_ => {
                completion.SetResult(VoidResult.Instance);
            });
        }
        private TaskCompletionSource<VoidResult> completion = new TaskCompletionSource<VoidResult>();
        public Task Completion => completion.Task;
        public void Complete() {
            Left.Complete();
            Right.Complete();
        }
        public void Fault(Exception exception) { throw new NotImplementedException(); }
        public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2>> target, DataflowLinkOptions linkOptions)
        {
            var leftLink = left.LinkTo(target);
            var rightLink = right.LinkTo(target);
            var link = new Link(leftLink, rightLink);
            Task task = Task.FromResult(0);
            if (linkOptions.PropagateCompletion)
            {
                task = Task.WhenAny(Task.WhenAll(Left.Completion, Right.Completion), link.Completion).ContinueWith(_ =>
                {
                    // If the link has been disposed of, we should not longer propagate completeness.
                    if (!link.Completion.IsCompleted)
                    {
                        target.Complete();
                    }
                });
            }
            return link;
        }
        public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
        {
            throw new NotImplementedException();
        }
        public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
        {
            throw new NotImplementedException();
        }
        public Tuple<T1, T2> ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target, out bool messageConsumed)
        {
            throw new NotImplementedException();
        }
        private class Link : IDisposable
        {
            private IDisposable leftLink;
            private IDisposable rightLink;
            public Link(IDisposable leftLink, IDisposable rightLink)
            {
                this.leftLink = leftLink;
                this.rightLink = rightLink;
            }
            private TaskCompletionSource<VoidResult> completionSource = new TaskCompletionSource<VoidResult>();
            public Task Completion { get { return completionSource.Task; } }
            public void Dispose()
            {
                leftLink.Dispose();
                rightLink.Dispose();
                completionSource.SetResult(VoidResult.Instance);
            }
        }
        private class VoidResult
        {
            public static VoidResult instance = new VoidResult();
            public static VoidResult Instance { get { return instance; } }
            protected VoidResult() { }
        }
    }
