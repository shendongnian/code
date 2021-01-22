    public class Score {
        private double m_marks;
        
        public double marks {
            get { return m_marks; }
            set { m_marks = value - (value % 0.01); }
        }
    }
