    public class DataAndTime
    {   
       private string m_Data = "";
       public string Data {
          get { return m_Data; }
          set { m_Data = value; }
       }
   
       private int m_TimeInMilliSeconds = 0;
       public int TimeInMilliSeconds {
          get { return m_TimeInMilliSeconds; }
          set { m_TimeInMilliSeconds = value; }
       } 
    }
