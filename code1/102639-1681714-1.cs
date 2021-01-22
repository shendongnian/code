                ICollection<KeyValuePair<String, int>> data = new Dictionary<String, int>();
                data.Add(new KeyValuePair<string, int>(Protocol, protocolCount));
                mycolseries = new ColumnSeries
                    {
                        ItemsSource = data,
                        Title = Protocol,
                        IndependentValuePath = "Key",                        
                        DependentRangeAxis =lamainChart,
                        DependentValuePath = "Value"
                        
                    };                
                mainChart.Series.Add(mycolseries); 
            
               
        }
