    public class DoubleTypeHandler : SqlMapper.TypeHandler<double>
    {
        public override void SetValue(IDbDataParameter parameter, double value)
        {
            throw new NotImplementedException();
        }
    
        public override double Parse(object value)
        {
            return value;
        }
    }
