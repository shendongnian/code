    public class IdentityHandler : SqlMapper.TypeHandler<MyEntityIdentity>
    {
        public override MyEntityIdentity Parse(object value)
        {
            return new MyEntityIdentity((int)value);
        }
        public override void SetValue(IDbDataParameter parameter, MyEntityIdentity value)
        {
            parameter.Value = value.IdentityValue;
        }
    }
