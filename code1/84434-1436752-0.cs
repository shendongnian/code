    public class SmartEnumMapping<T> : IUserType
        {
            #region IUserType Members
    
            public object Assemble(object cached, object owner)
            {
                return cached;
            }
    
            public object DeepCopy(object value)
            {
                return value;
            }
    
            public object Disassemble(object value)
            {
                return value;
            }
    
            public int GetHashCode(object x)
            {
                return x.GetHashCode();
            }
    
            public bool IsMutable
            {
                get { return false; }
            }
    
            public new bool Equals(object x, object y)
            {
                return object.Equals(x, y);
            }
    
            public object NullSafeGet(System.Data.IDataReader rs, string[] names, object owner)
            {
                int index0 = rs.GetOrdinal(names[0]);
                if (rs.IsDBNull(index0))
                {
                    return null;
                }
                string key = rs.GetString(index0);
                return EnumExtensions.EnumParseKey<T>(key, false, true);
            }
    
            public void NullSafeSet(System.Data.IDbCommand cmd, object value, int index)
            {
                if (value == null)
                {
                    ((IDbDataParameter)cmd.Parameters[index]).Value = DBNull.Value;
                }
                else
                {
                    T enumValue = (T)Enum.Parse(typeof(T), value.ToString());
                    ((IDbDataParameter)cmd.Parameters[index]).Value = enumValue.GetKey();
                }
            }
    
            public object Replace(object original, object target, object owner)
            {
                return original;
            }
    
            public Type ReturnedType
            {
                get { return typeof(T); }
            }
    
            public global::NHibernate.SqlTypes.SqlType[] SqlTypes
            {
                get { return new SqlType[] { SqlTypeFactory.GetString(4096) }; }
            }
    
            #endregion
    }
