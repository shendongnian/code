    public class CarStore : IEnumerable<Car> { 
        Car[] m_collection = new Car[2];
    
        public CarStore()
        {
            // Indexes adjusted - C# arrays are 0-based
            m_collection[0] = new Car { Speed = 100, Color = "red" };
            m_collection[1] = new Car { Speed = 200, Color = "yellow" };
        }
    
        public IEnumerator<Car> GetEnumerator() {
            return m_collection.GetEnumerator();
        }
        public IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
