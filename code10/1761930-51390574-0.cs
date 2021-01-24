    private static void RunString()
            {
                var recordList = new List<string> {"1", "two", "three", "four", "five", "six"};
    
                var result = new ConcurrentBag<ProcessedData>();
                Parallel.ForEach(recordList
                    , record => //body
                    {
                        var integerValue = record.Length;
                        var processedString = record + " Processed";
    
                        var processedData = new ProcessedData
                        {
                            IntegerValue = integerValue,
                            StringValue = processedString
                        };
                        result.Add(processedData);
                    });
    
                var myDataSet = new DataSet();
                var myTable = myDataSet.Tables.Add();
    
                myTable.Columns.Add("NumberVal", typeof(int));
                myTable.Columns.Add("TextVal", typeof(string));
                foreach (var item in result)
                {
                    Console.WriteLine($"{item.IntegerValue} has {item.StringValue}");
                    myTable.Rows.Add(item.IntegerValue, item.StringValue);
                }
            }
    
            private sealed class ProcessedData
            {
                internal int IntegerValue { get; set; }
                internal string StringValue { get; set; }
            }
