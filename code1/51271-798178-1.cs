    public abstract class BaseData : IEquatable<BaseData>
    {
        public abstract bool Equals(BaseData other);
    }
    public class DataTypeOne : BaseData
    {
        public string Name;
        public string Address;
        public override bool Equals(BaseData other)
        {
            var o = other as DataTypeOne;
            if(o == null)
                return false;
            return Name.Equals(o.Name) && Address.Equals(o.Address);
        }
    }
    public class DataTypeTwo : BaseData
    {
        public int CustId;
        public string CustName;
        public override bool Equals(BaseData other)
        {
            var o = other as DataTypeTwo;
            if (o == null)
                return false;
            return CustId == o.CustId && CustName.Equals(o.CustName);
        }
    }
