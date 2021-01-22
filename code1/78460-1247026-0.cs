    public class MyDataRow : DataRow
    {
        public DateTime? SomeDate
        {
            get
            {
                return (this["SomeDate"] is DBNull)
                   ? (DateTime?)null
                   : this.Field<DateTime>("SomeDate");
            }
            set
            {
                if (value == null)
                {
                    this["SomeDate"] = DBNull.Value;
                }
                else
                {
                    this["SomeDate"] = value;
                }
            }
        }
    }
