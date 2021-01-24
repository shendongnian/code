    public class TargetData
    {
        [ColumnName("PredictedLabel")]
        public bool Value { get; set; }
    
        public float Score { get; set; }
        public float Probability { get; set; }
        public string RowId { get; set; }
    }
