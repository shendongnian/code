    public class DateTimeHandler : SqlMapper.TypeHandler<DateTime>
    {
        public override void SetValue(IDbDataParameter parameter, DateTime value)
        {
                parameter.Value = value.ToString("YYYYMMDDTHHmmss");
        }
    
        public override DateTime Parse(object value)
        {
          return DateTime.SpecifyKind(DateTime.ParseExact((string)value,     "yyyyMMddTHHmmss", CultureInfo.InvariantCulture), DateTimeKind.Utc);
        }
    }
