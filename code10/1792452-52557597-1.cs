    public class Genes 
    {
        private float Size { get; set; }
        private float Speed { get; set; }
        private float Probability { get; set; }
        private int Color { get; set; }
    
        public Genes(float size, float speed, float probability, int color) 
        {
            this.Size = size; 
            this.Speed = speed; 
            this.Probability = probability; 
            this.Color = color; 
        }
    }
