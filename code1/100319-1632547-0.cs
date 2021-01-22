    public class CauseAssignment
    {
        private string _Path;
        /* the rest of your code */
        public override bool Equals( object o )
        { 
            if( o == null || o.GetType() != typeof(CauseAssignment) )
                return false;
            CauseAssignment ca = (CauseAssignment)o;
            return ca._Path.Equals( this._Path );
        }
        public override int GetHashCode()
        {
            return _Path.GetHashCode();
        }
    }
