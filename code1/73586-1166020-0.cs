    private void button1_Click(object sender, EventArgs e)
        {
            IList<BorderFlowHistoryElement> clusterHistory = FillClusterHistory();
            dataGridView1.DataSource = clusterHistory;
            dataGridView1.Columns[1].DefaultCellStyle.Format = "n5";
            
            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }
        private static IList<BorderFlowHistoryElement> FillClusterHistory()
        {
            IList<BorderFlowHistoryElement> clusterHistory = new   List<BorderFlowHistoryElement>();
            for(int i = 5000; i < 5020; i++)
            {
                BorderFlowHistoryElement element = new BorderFlowHistoryElement();
                element.nodeTitles = Guid.NewGuid().ToString();
                
                element.borderFlowRatio = i * 3.3.1415672467234823499821D;
                clusterHistory.Add(element);
            }
            return clusterHistory;
        }
    }
    public class BorderFlowHistoryElement
    {
        private string _NodeTitles;
        private double _BorderFlowRatio;
        public string nodeTitles
        {
            get { return _NodeTitles; }
            set { _NodeTitles = value;}
        }
        public double borderFlowRatio
        {
            get { return _BorderFlowRatio; }
            set { _BorderFlowRatio = value;}
        }
    }
