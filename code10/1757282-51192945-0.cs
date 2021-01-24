    using System.Linq;
    using System.Text;
    
    namespace StringManipulation
    {
        class Program
        {
            static void Main(string[] args)
            {
                string sql = "100 \n  200 \n 500 \n 1000";
                string html = GetHTMLForSQL(sql);
            }
    
            private static string GetHTMLForSQL(string sql)
            {
                int[] values = sql.Split('\n')
                    .Select(s => int.Parse(s.Trim()))
                    .ToArray();
    
                StringBuilder html = new StringBuilder();
                foreach (int val in values)
                {
                    html.Append("<p" + (val >= 500 ? " style='color:red;'" : "") + ">" + val + "</p>");
                }
                return html.ToString();
            }
        }
    }
