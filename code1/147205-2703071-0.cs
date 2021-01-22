    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace StringParsingWithLinq
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                var inputs = new List<string>
                                 {
                                     "FirstName,LastName,Title,BirthDate,HireDate,City,Region",
                                     "Nancy,Davolio,Sales Representative,1948-12-08,1992-05-01,Seattle,WA",
                                     "Andrew,Fuller,Vice PresidentSales,1952-02-19,1992-08-14,Tacoma,WA",
                                     "Janet,Leverling,Sales Representative,1963-08-30,1992-04-01,Kirkland,WA",
                                     "Margaret,Peacock,Sales Representative,1937-09-19,1993-05-03,Redmond,WA",
                                     "Steven,Buchanan,Sales Manager,1955-03-04,1993-10-17,London,NULL",
                                     "Michael,Suyama,Sales Representative,1963-07-02,1993-10-17,London,NULL",
                                     "Robert,King,Sales Representative,1960-05-29,1994-01-02,London,NULL",
                                     "Laura,Callahan,Inside Sales Coordinator,1958-01-09,1994-03-05,Seattle,WA",
                                     "Anne,Dodsworth,Sales Representative,1966-01-27,1994-11-15,London,NULL"
                                 };
    
                Console.Write(FixedWidthHelper.ReadLines(inputs)
                                  .ToFixedLengthString());
                Console.ReadLine();
            }
    
            #region Nested type: FixedWidthHelper
    
            public class FixedWidthHelper
            {
                private readonly List<string[]> _data = new List<string[]>();
                private List<int> _fieldLen;
    
                public static FixedWidthHelper ReadLines(List<string> lines)
                {
                    var fw = new FixedWidthHelper();
                    lines.ForEach(fw.AddDelimitedLine);
                    return fw;
                }
    
                private void AddDelimitedLine(string line)
                {
                    string[] fields = line.Split(',');
    
                    if (_fieldLen == null)
                        _fieldLen = new List<int>(fields.Select(f => f.Length));
    
                    for (int i = 0; i < fields.Length; i++)
                    {
                        if (fields[i].Length > _fieldLen[i])
                            _fieldLen[i] = fields[i].Length;
                    }
    
                    _data.Add(fields);
                }
    
                public string ToFixedLengthString()
                {
                    var sb = new StringBuilder();
                    foreach (var list in _data)
                    {
                        for (int i = 0; i < list.Length; i++)
                        {
                            sb.Append(list[i].PadRight(_fieldLen[i] + 1, ' '));
                        }
                        sb.AppendLine();
                    }
    
                    return sb.ToString();
                }
            }
    
            #endregion
        }
    }
