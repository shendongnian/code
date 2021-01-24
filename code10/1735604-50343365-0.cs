    class FilterMatrix {
        private List<Feature> features = new List<Feature>();  
        public List<Feature> FeaturesList
        {
            get { return features; }
            set { features = value; }
        }
    }
    
    class Feature {
        public int ID { get; set; }
        public int ParentID { get; set; }
    }
