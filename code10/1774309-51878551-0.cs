    public class Cat
    {
        private string name;
        private float weight;
        private float speed;
    
        public Cat()
        {
            this.name = "";
            this.weight = 0.0;
            this.speed = 0.0;
        }
    
        public void SetName(string name)
        {
            this.name = name;
        }
    
        public void SetWeight(float weight)
        {
            this.weight = weight;
        }
    
        public void SetSpeed(float speed)
        {
            this.speed = speed;
        }
        public string GetName()
        {
            return this.name;
        }
    
        public float GetWeight() 
        {
            return this.weight;
        }
    
        public float GetSpeed()
        {
            return this.speed;
        }
    }
