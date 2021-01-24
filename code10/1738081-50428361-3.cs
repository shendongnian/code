    [DebuggerDisplay("Count = {Count}")]
    [DebuggerTypeProxy(typeof(BetterListDebuggerView))]
    public class BetterList: List<SomeType> {
        //...
        public int Count { get; }
        
        internal class BetterListDebuggerView {
            private BetterList list;
            public BetterListDebuggerView(BetterList list) {
                this.list = list;
            }
            
            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
            public SomeType[] Items {
                get {
                    return list.ToArray();
                }
            }
        }
    }
