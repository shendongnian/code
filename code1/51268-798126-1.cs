    public class DataTypeTwo : BaseData, IEquatable<DataTypeTwo>
    {
        public int CustId;
        public string CustName;
        public override int GetHashCode()
        {
            return CustId ^ CustName.GetHashCode(); // or whatever
        }
        public override bool Equals(object other)
        {
            return this.Equals(other as DataTypeTwo);
        }
      
        public bool Equals(DataTypeTwo other)
        {
            return (other != null &&
                    other.CustId == this.CustId &&
                    other.CustName == this.CustName);
        }
    }
