    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.IO;
    
    class Program
    {
        static void Main(string[] args)
        {
    
            string inputFilename = "input.txt";
            string outputFilename = "output.txt";
    
            string[] dateColumnNames = { "DDate" };
    
            using (StreamReader stream = new StreamReader(File.Open(inputFilename, FileMode.Open)))
            using (StreamWriter writer = new StreamWriter(File.Open(outputFilename, FileMode.Create)))
            {
                int[] dateColumns = new int[0];
    
                while (true)
                {
                    string line = stream.ReadLine();
                    if (line == null)
                        break;
    
                    // Split into columns.
                    string[] columns = line.Split('|');
    
                    // Find date columns.
                    int[] newDateColumns =
                        columns.Select((name, index) => new { Name = name, Index = index })
                        .Where(x => dateColumnNames.Contains(x.Name))
                        .Select(x => x.Index)
                        .ToArray();
    
                    if (newDateColumns.Length > 0)
                        dateColumns = newDateColumns;
    
                    // Replace dates.
                    foreach (int i in dateColumns)
                    {
                        if (columns.Length > i)
                        {
                            Regex regex = new Regex(@"(\d{4})(\d{2})(\d{2})");
                            columns[i] = regex.Replace(columns[i], "$2/$3/$1");
                            line = string.Join("|", columns);
                        }
                    }
    
                    // Make other replacements.
                    line = line.Replace(@"BegAtt|EndAtt", "BegAtt#|EndAtt#");
                    line = line.Replace(@"Cc|*RFP", "CC|RFP");
                    line = line.Replace(@"<swme> ", string.Empty);
                    line = line.Replace(@" </swme>", ";");
    
                    // Output line.
                    writer.WriteLine(line);
                }
            }
        }
    }
