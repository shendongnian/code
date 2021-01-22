        [Serializable]
        public class data
        {
          private int m_MyInteger;
          // New field
          private double m_MyDouble;
        
          [OnDeserializing]
          internal void OnDeserializing(StreamingContext context)
          {
            // some good default value
            m_MyDouble = 5;
          }
        
          public int MyInteger
          {
            get{ return m_MyInteger; }
            set { m_MyInteger = value; }
          }
       }
