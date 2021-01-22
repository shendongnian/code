    private void DrawChart() {
    
    ArrayList ar= new ArrayList();
    ar.Add("one");
        ar.Add("two");
        ar.Add("three");
    
            for (int i = 0; i <ar.count ; i++)
            {
                               addRecursiveLedgendAfterInit(ar[i], 50);
            }
        }
    private void addRecursiveLedgendAfterInit(string legend,int legendvalue) {
    
            ICollection<KeyValuePair<String, int>> data = new Dictionary<String, int>();
            data.Add(new KeyValuePair<string, int>(legend, legendvalue));
    
                ColumnSeries mycolseries = new ColumnSeries
                {
                    ItemsSource = data,
    
                    Title = legend,
                    IndependentValuePath = "Key",
                    DependentValuePath = "Value",
    
                };
    
                mainChart.Series.Add(mycolseries);
        }
