    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Data;
    using System.Threading.Tasks;
    namespace ConsoleApplication100
    {
        class Program
        {
    		static void Main(string[] args)
    		{
    		}
        }
        public class test
        {
            private void Btn_Import_Click(object sender, RoutedEventArgs e)
            {
                /*ILRChecks.ILRReport.NullChecks();
                ILRChecks.ILRReport.CrossYear();*/
                DataSet dataSet = new DataSet();
                DataTable diff = new DataTable();
                diff.TableName = "Differences";
                diff.Columns.Add("LearnRefNumber");
                diff.Columns.Add("ULN");
                //diff.Columns.Add("FamilyName");
                //diff.Columns.Add("GivenNames");
                diff.Columns.Add("DateofBirth");
                diff.Columns.Add("NINumber");
                diff.Columns.Add("Message");
                Dictionary<int, DataTable> Tables = new Dictionary<int, DataTable>();
                foreach (string str_FileLocation in Global.fileNames)
                {
                    FileInfo fileInfo = new FileInfo(str_FileLocation);
                    string str_xmlFileName = fileInfo.Name;
                    XDocument doc = XDocument.Load(str_FileLocation);
                    var ns = doc.Root.GetDefaultNamespace();
                    var learner = doc.Descendants(ns + "Learner");
                    string shortfile = str_xmlFileName.Substring(13, 4);
                    StringReader reader = new StringReader(new XElement("Sample", learner).ToString());
                    DataTable dt = new DataTable();
                    dt.ReadXml(reader);
                    Tables.Add(int.Parse(shortfile), dt);
                }
                var orderTables = Tables.OrderByDescending(k => k.Key).ToList();
                for (int i = 1; i <= orderTables.Count(); i--)
                {
                    var diff_ULNDOB = from Latest in orderTables[i].AsEnumerable()
                                    join previous in orderTables[i - 1].AsEnumerable()
                                    on Latest.Field<string>("ULN") equals previous.Field<string>("ULN")
                                    where Latest.Field<string>("DateofBirth") != previous.Field<string>("DateofBirth")
                                    select new { ULN = Latest.Field<string>("ULN"), FamilyName = Latest.Field<string>("FamilyName") };
                }
            }
        }
    }
