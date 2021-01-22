    public class Control  
    {  
     protected Point m_Position = new Point();  
      
     public float PositionX
     {  
      get { return m_Position.X; }  
      set   
      {   
        m_Position.X = value; }  
        // reorganize internal structure..  
        reorganize();  
      }  
       
      ... Same thing for PositionY
      protected reorganize()  
      {  
       // do some stuff  
      }  
    }
