    public class Point
    {
     public float X;
     public float Y;
    }
    
    public class Control
    {
     protected Point m_Position = new Point();
    
     public Point Position
     {
      get 
      { 
          if (m_Position == null) m_Position = new Point();
          return m_Position; 
      }
      set 
      { 
        m_Position = value; 
        // reorganize internal structure..
        reorganize();
      }
       
      }
    
      protected reorganize()
      {
       // do some stuff
      }
    }
