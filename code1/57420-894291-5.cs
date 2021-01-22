    public sealed class Peeker
    {
        internal readonly PeekMode PEEKING;
        internal readonly NormalMode NORMAL;
    
        private ReadState _state;
    
        public Peeker()
        {
            PEEKING = new PeekMode(this);
            NORMAL = new NormalMode(this);
    
            // Start with a normal mode
            _state = NORMAL;
        }
    
        public object[] OnRead(IDataReader dr, bool peek)
        {
            return _state.OnRead(dr, peek);
        }
    
        internal void SetState(ReadState state)
        {
            _state = state;
        }
    }
    
    internal abstract class ReadState
    {
        protected Peeker _peeker;
    
        protected ReadState(Peeker p)
        {
            _peeker = p;
        }
    
        public abstract object[] OnRead(IDataReader dr, bool peek);        
    }
    
    internal class PeekMode : ReadState
    {
        public PeekMode(Peeker p)
            : base(p)
        {
        }
    
        public override object[] OnRead(IDataReader dr, bool peek)
        {
            object[] datarow = new object[dr.FieldCount];
    
            if (peek)
            {                
                dr.GetValues(datarow);                
            }
            else
            {
                if (dr.Read())
                {
                    dr.GetValues(datarow);
                    _peeker.SetState(_peeker.NORMAL);
                }
            }
    
            return datarow;
        }
    }
    
    internal class NormalMode : ReadState
    {
        public NormalMode(Peeker p)
            : base(p)
        {
        }
    
        public override object[] OnRead(IDataReader dr, bool peek)
        {
            object[] datarow = new object[dr.FieldCount];
    
            if (peek)
            {
                if (dr.Read())
                {
                    dr.GetValues(datarow);
                    _peeker.SetState(_peeker.PEEKING);
                }
            }
            else
            {
                if (dr.Read())
                {
                    dr.GetValues(datarow);
                }
            }
    
            return datarow;
        }
    }
