    public class AnnotationBreakDown : INotifyPropertyChanged
    {
        public string Position { get; set; } // To raise PropertyChanged 
        public string Type { get; set;} // To raise PropertyChanged 
        public float Pot { get; set; } // To raise PropertyChanged 
        public float Current { get; set; } // To raise PropertyChanged 
        public float CurrentDensity { get; set; } // To raise PropertyChanged 
        public float FieldGradient { get; set; } // To raise PropertyChanged 
        public float MC { get; set; } //McCoy Current
        public float MCD { get; set;} //McCoy CD
        public float MFG { get; set; } //McCoy FG
    }
