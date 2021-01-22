    public partial class SolidObject
    {
        public Rect Bounds
        {
            get
            {
                return new Rect(Position.X - Size.Width / 2, Position.Y - Size.Height / 2, Size.Width, Size.Height);
            }
        }
    
        [OnDeserialized]
        private void Initialize(StreamingContext streamingContext)
        {
            PropertyChanged += (sender, e) =>
            {
                if ((e.PropertyName == "Position") || (e.PropertyName == "Size"))
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Bounds"));
            };
        }
    }
