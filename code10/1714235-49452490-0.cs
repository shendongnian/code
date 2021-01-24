         var csv = new StringBuilder();
                csv.AppendLine("Header1;Header2;Header3;Header4");
                foreach (var item in file)
                {
                    var newLine = string.Format("{0},{1},{2},{3}", item.value1, item.value2, item.value3, item.value4);
                    csv.AppendLine(newLine);
                }
                //Create Stream
                MemoryStream stream = new MemoryStream();
                StreamReader reader = new StreamReader(stream);
                
                //Fill your data table here with your values
