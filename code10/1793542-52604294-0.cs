    class Room
    {
        private Double m_DblLength;
        private Double m_DblWidth;
    
        public Room (Double _dblLength, Double _dblWidth) {
          DblLength = _dblLength;
          DblWidth = _dblWidth;
        }
    
        public Double DblLength {
          get {
            return m_DblLength;
          }
          set {
            //TODO: validation here
            if (value < 0)
              throw new ArgumentOutOfRangeException("value"); 
    
            m_DblLength = value;
          }
        }
        
        public Double DblWidth {
          get {
            return m_DblWidth;
          }
          set {
            //TODO: validation here
            if (value < 0)
              throw new ArgumentOutOfRangeException("value"); 
    
            m_DblWidth = value;
          }
        }
