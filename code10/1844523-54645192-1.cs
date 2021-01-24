    class CancerData
    {
        [LoadColumn(0)]
        public string Diagnosis {get;set;}
    
        [LoadColumn(1, 30), ColumnName("Features")]
        public float[] FeatureVector { get; set; }
        [LoadColumn(31)]
        public float Target { get; set; }
    }
