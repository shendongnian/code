    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web.UI;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var columns = new CommaSeparated();
                columns.Add("tag");
                columns.Add("instrumenttag");
                columns.Add("pointsource");
                columns.Add("pointtype");
                columns.Add("dataowner");
                columns.Add("dataaccess");
                columns.Add("location1");
                columns.Add("location2");
                columns.Add("location3");
                columns.Add("location4");
                columns.Add("location5");
                columns.Add("...");
                var values = new CommaSeparated();
                values.EncloseEachElementWith = "'";
                values.Add(createTagRow["tag"].ToString());
                values.Add(createTagRow["instrumenttag"].ToString());
                values.Add(createTagRow["pointsource"].ToString());
                values.Add(createTagRow["pointtype"].ToString());
                values.Add(createTagRow["dataowner"].ToString());
                values.Add(createTagRow["dataaccess"].ToString());
                values.Add(createTagRow["location1"].ToString());
                values.Add(createTagRow["location2"].ToString());
                values.Add(createTagRow["location3"].ToString());
                values.Add(createTagRow["location4"].ToString());
                values.Add(createTagRow["location5"].ToString());
                values.Add(createTagRow["..."].ToString());
                //INSERT INTO MASTERPI ({columns}) values ({values})
                var query = "INSERT INTO MASTERPI ({columns}) values ({values})".FormatWith(new { columns, values });
                Console.WriteLine(query);
                Console.ReadKey();
            }
        }
        public class CommaSeparated : List<string>
        {
            public CommaSeparated()
                : base()
            {
                EncloseEachElementWith = String.Empty;
            }
            public override string ToString()
            {
                var elements = this.Select(element => String.Format("{0}{1}{0}", EncloseEachElementWith, element));
                return String.Join(", ", elements.ToArray());
            }
            public string EncloseEachElementWith { get; set; }
        }
        public static class StringExtensions
        {
            public static string FormatWith(this string format, object source)
            {
                return FormatWith(format, null, source);
            }
            public static string FormatWith(this string format, IFormatProvider provider, object source)
            {
                if (format == null)
                    throw new ArgumentNullException("format");
                Regex r = new Regex(@"(?<start>\{)+(?<property>[\w\.\[\]]+)(?<format>:[^}]+)?(?<end>\})+",
                  RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);
                List<object> values = new List<object>();
                string rewrittenFormat = r.Replace(format, delegate(Match m)
                {
                    Group startGroup = m.Groups["start"];
                    Group propertyGroup = m.Groups["property"];
                    Group formatGroup = m.Groups["format"];
                    Group endGroup = m.Groups["end"];
                    values.Add((propertyGroup.Value == "0")
                      ? source
                      : DataBinder.Eval(source, propertyGroup.Value));
                    return new string('{', startGroup.Captures.Count) + (values.Count - 1) + formatGroup.Value
                      + new string('}', endGroup.Captures.Count);
                });
                return string.Format(provider, rewrittenFormat, values.ToArray());
            }
        }
    }
