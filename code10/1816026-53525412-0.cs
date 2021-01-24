    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication86
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Type", typeof(int));
                dt.Columns.Add("DateTime", typeof(DateTime));
                dt.Columns.Add("Value", typeof(float));
                dt.Rows.Add(new object[] {4711, DateTime.Parse("2018-01-01"), 0.7 });
                dt.Rows.Add(new object[] {4711, DateTime.Parse("2018-01-02"), 0.8 });
                dt.Rows.Add(new object[] {4711, DateTime.Parse("2018-01-03"), 0.9 });
                dt.Rows.Add(new object[] {4711, DateTime.Parse("2018-01-04"), 1.0 });
                dt.Rows.Add(new object[] {4712, DateTime.Parse("2018-01-01"), 3.2 });
                dt.Rows.Add(new object[] {4712, DateTime.Parse("2018-01-02"), 2.7 });
                dt.Rows.Add(new object[] {4712, DateTime.Parse("2018-01-03"), 5.6 });
                dt.Rows.Add(new object[] {4712, DateTime.Parse("2018-01-04"), 1.9 });
                var groups = dt.AsEnumerable().GroupBy(x => x.Field<int>("Type")).ToList();
                List<TypeMaster> data = (from g in groups
                                         select new { grp = new TypeMaster() { Type = g.Key }, rows = g })
                           .Select(x => new TypeMaster() {
                               Type = x.grp.Type,
                               Values = x.grp.Values = x.rows.Select(y => new TypeValue() {
                                       TimeStamp = y.Field<DateTime>("DateTime"),
                                       Value = y.Field<float>("Value"),
                                       Index = x.grp
                                   }).ToList()
                           }).ToList();
             }
     
        }
        [Table("TypeValues")]
        public class TypeMaster
        {
            [Column("Type")]
            public int Type { get; set; }
            [ForeignKey("Type")]
            public virtual ICollection<TypeValue> Values { get; set; }
        }
        [Table("TypeValues")]
        public class TypeValue
        {
            [Column("DateTime")]
            public DateTime TimeStamp { get; set; }
            [Column("Value")]
            public float? Value { get; set; }
            public TypeMaster Index { get; set; }
        }
     
     
    }
