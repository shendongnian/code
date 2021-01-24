    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication31
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Group", typeof(string));
                dt.Columns.Add("Parent", typeof(string));
                dt.Columns.Add("Child", typeof(string));
                dt.Rows.Add(new object[] { "Group1Name", null, "Group1Value1" });
                dt.Rows.Add(new object[] { "Group1Name", "Group1Value1", "Group2Value1" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value1", "Group3Value1" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value1", "Group3Value2" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value1", "Group3Value3" });
                dt.Rows.Add(new object[] { "Group1Name", "Group1Value1", "Group2Value2" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value2", "Group3Value1" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value2", "Group3Value2" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value2", "Group3Value3" });
                dt.Rows.Add(new object[] { "Group1Name", "Group1Value1", "Group2Value3" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value3", "Group3Value1" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value3", "Group3Value2" });
                dt.Rows.Add(new object[] { "Group1Name", "Group2Value3", "Group3Value3" });
                dt.Rows.Add(new object[] { "Group2Name", null, "Group1Value2" });
                dt.Rows.Add(new object[] { "Group2Name", "Group1Value2", "Group2Value1" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value1", "Group3Value1" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value1", "Group3Value2" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value1", "Group3Value3" });
                dt.Rows.Add(new object[] { "Group2Name", "Group1Value2", "Group2Value2" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value2", "Group3Value1" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value2", "Group3Value2" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value2", "Group3Value3" });
                dt.Rows.Add(new object[] { "Group2Name", "Group1Value2", "Group2Value3" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value3", "Group3Value1" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value3", "Group3Value2" });
                dt.Rows.Add(new object[] { "Group2Name", "Group2Value3", "Group3Value3" });
                new ItemSet(dt);
            }
        }
        public class ItemSet
        {
            public static Dictionary<string, ItemSet> GroupDictionary = new Dictionary<string, ItemSet>();
            public string name { get; set; }
            public List<ItemSet> sets { get; set; }
            public DataRow items { get; set; }
            public ItemSet() { }
            public ItemSet(DataTable dt)
            {
                var groups = dt.AsEnumerable()
                    .GroupBy(x => x.Field<string>("Group")).ToList();
                foreach(var group in groups)
                {
                    ItemSet root = new ItemSet();
                    ItemSet.GroupDictionary.Add(group.Key, root);
                    RecursiveAdd(root, group.ToList());
                }
                
            }
            public void RecursiveAdd(ItemSet parent, List<DataRow> rows)
            {
                foreach (DataRow row in rows.Where(x => x.Field<string>("Parent") == parent.name))
                {
                    ItemSet newItemSet = new ItemSet();
                    newItemSet.name = (string)row["Child"];
                    newItemSet.items = row;
                    if (parent.sets == null) parent.sets = new List<ItemSet>();
                    parent.sets.Add(newItemSet);
                    RecursiveAdd(newItemSet, rows);
                }
            }
        }
    }
