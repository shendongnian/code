    class NullableDateTime : IUserType
    {
        #region IUserType Members
        public new bool Equals(object obj, object obj2)
        {
            return false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public object DeepCopy(object value)
        {
            return value;
        }
        public bool IsMutable
        {
            get { return true; }
        }
        public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
        {
            object o = rs[names[0]];
            if (o == DBNull.Value) return new Nullable<DateTime>();
            else
                return new Nullable<DateTime>(((System.Data.SqlTypes.SqlDateTime)o).Value);
        }
        public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
        {
            System.Data.Common.DbParameter parameter = (System.Data.Common.DbParameter)cmd.Parameters[index];
            if (value == null)
            {
                parameter.Value = DBNull.Value;
                return;
            }
            else
            {
                parameter.Value = new System.Data.SqlTypes.SqlDateTime((DateTime)value);
            }
        }
        public Type ReturnedType
        {
            get { return this.GetType(); }
        }
        public NHibernate.SqlTypes.SqlType[] SqlTypes
        {
            get { return new NHibernate.SqlTypes.SqlType[] { new SqlDateTimeType() }; }
        }
        #endregion
    }
       
    public class SqlDateTimeType : NHibernate.SqlTypes.SqlType
    {
        public SqlDateTimeType() : base(System.Data.DbType.DateTime)
        {
        }
    }
