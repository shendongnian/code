    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using gudusoft.gsqlparser;
    
    namespace GeneralSqlParserTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                TGSqlParser sqlparser = new TGSqlParser(TDbVendor.DbVMssql);
    
                sqlparser.SqlText.Text = "SELECT * FROM Customers c, Addresses a WHERE c.CustomerName='foo'";
                sqlparser.OnTableToken += new TOnTableTokenEvent(OnTableToken);
    
                int result = sqlparser.Parse();
                Console.ReadLine();
            }
    
            static void OnTableToken(object o, gudusoft.gsqlparser.TSourceToken st, gudusoft.gsqlparser.TCustomSqlStatement stmt)
            {
                Console.WriteLine("Table: {0}", st.AsText);
            }
        }
    }
