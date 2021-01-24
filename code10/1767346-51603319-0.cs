    namespace Commons
    {
        public class MyTimeSpanConverter : TimeSpanAsIntConverter
        {
            public override string ColumnDefinition => "TIME";
            public override DbType DbType => DbType.Time;
    
            public override object ToDbValue(Type fieldType, object value)
            {
                TimeSpan timespan = (TimeSpan)value;
                return timespan;
            }
            
        }
    }
