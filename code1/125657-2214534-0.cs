    [DataContract]
    public class SolidObject
    {
       [DataMember]
       public Point Position
        {
            get { return _position; }
            set 
              { 
               position = value; 
               FirePropertyChanged("Position");
               FirePropertyChanged("Bounds");
               }
        }
    
        public Size Size
        {  
         //similar to position
        }
        
        public Rect Bounds { get { return new Rect(Position.X - Size.Width / 2, Position.Y - Size.Height / 2, Size.Width, Size.Height); }}
    }
