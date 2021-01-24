       public class Car
        {
            public string name;
            public int speed;
            public Car(string name, int speed)
            {
                this.name = name;
                this.speed = speed;
            }
        
            public override string ToString()
            {
                return $"{name} {speed}";
        
            }
        }
