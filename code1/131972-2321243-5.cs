    class MsgTypeCounter : IMsgVisitor<MsgTypeCounter>
    {
        public readonly Tuple<int, int, int> State;    
        
        public MsgTypeCounter(Tuple<int, int, int> state) { this.State = state; }
    
        public MsgTypeCounter Visit(Add msg)
        {
            Console.WriteLine("got Add of " + msg.Value);
            return new MsgTypeCounter(Tuple.Create(1 + State.Item1, State.Item2, State.Item3));
        }
    
        public MsgTypeCounter Visit(Sub msg)
        {
            Console.WriteLine("got Sub of " + msg.Value);
            return new MsgTypeCounter(Tuple.Create(State.Item1, 1 + State.Item2, State.Item3));
        }
    
        public MsgTypeCounter Visit(Query msg)
        {
            Console.WriteLine("got Query of " + msg.Value);
            return new MsgTypeCounter(Tuple.Create(State.Item1, 1 + State.Item2, State.Item3));
        }
    }
