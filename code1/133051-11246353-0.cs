    public class VarcharMax : BaseImmutableUserType<String>
    {
        public override object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            return  (string)NHibernateUtil.String.NullSafeGet(rs, names[0]);
        }
        public override void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            //Change the size of the parameter
            ((IDbDataParameter)cmd.Parameters[index]).Size = int.MaxValue;
            NHibernateUtil.String.NullSafeSet(cmd, value, index);
        }
        public override SqlType[] SqlTypes
        {
            get { return new[] { new SqlType(DbType.String) }; }
        }
    }
    public abstract class BaseImmutableUserType<T> : NHibernate.UserTypes.IUserType
    {
        public abstract object NullSafeGet(IDataReader rs, string[] names, object owner);
        public abstract void NullSafeSet(IDbCommand cmd, object value, int index);
        public abstract SqlType[] SqlTypes { get; }
    
        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
    
            return x.Equals(y);
        }
    
        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }
    
        public object DeepCopy(object value)
        {
            return value;
        }
        
        public object Replace(object original, object target, object owner)
        {
            return original;
        }
    
        public object Assemble(object cached, object owner)
        {
            return DeepCopy(cached);
        }
    
        public object Disassemble(object value)
        {
            return DeepCopy(value);
        }
    
        public Type ReturnedType
        {
            get { return typeof(T); }
        }
    
        public bool IsMutable
        {
            get { return false; }
        }
    }
