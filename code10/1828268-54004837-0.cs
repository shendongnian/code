    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication94
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("parentname", typeof(string));
                dt.Columns.Add("parentid", typeof(int));
                dt.Columns.Add("childname", typeof(string));
                dt.Columns.Add("childid", typeof(int));
                DataTable dtChildPerson = new DataTable();
                dtChildPerson.Columns.Add("ChildPersonID", typeof(int));
                dtChildPerson.Columns.Add("ParentPersonID", typeof(int));
                dtChildPerson.Rows.Add(new object[] { 1, 1 });
                dtChildPerson.Rows.Add(new object[] { 1, 3 });
                dtChildPerson.Rows.Add(new object[] { 2, 4 });
                DataTable personName = new DataTable();
                personName.Columns.Add("ID", typeof(int));
                personName.Columns.Add("PersonName", typeof(string));
                personName.Rows.Add(new object[] { 1, "a" });
                personName.Rows.Add(new object[] { 2, "b" });
                personName.Rows.Add(new object[] { 3, "c" });
                personName.Rows.Add(new object[] { 4, "d" });
                foreach (DataRow row in dtChildPerson.AsEnumerable())
                {
                    int parentID = row.Field<int>("ParentPersonID");
                    string parentName = personName.AsEnumerable().Where(x => x.Field<int>("ID") == parentID).Select(x => x.Field<string>("PersonName")).FirstOrDefault();
                    int childID = row.Field<int>("ChildPersonID");
                    
                    foreach(DataRow childRow in personName.AsEnumerable().Where(x => x.Field<int>("ID") == childID))
                    {
                        string childName = childRow.Field<string>("PersonName");
                        dt.Rows.Add(new object[] { parentName, parentID, childName, childID });
                    }
                }
            }
        }
    }
        
