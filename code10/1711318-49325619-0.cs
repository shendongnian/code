	public struct CarHandle
	{
		internal int m_id;
		internal CarHandle(int id)
		{
			m_id = id;
		}
		public int ID { get { return m_id; } }
	}
	public class CarManager
	{
		private struct CarData
		{
			public int Speed;
			public int Size;
		}
		
        private List<CarData> m_cars = new List<CarData>();
		private List<int> m_removedCars = new List<int>();
		
        public CarHandle CreateCar(int speed, int size)
		{
			var carData = new CarData() { Speed = speed, Size = size };
			// see if there is an empty slot we can use
			if (m_removedCars.Count > 0)
			{
				int ix = m_removedCars[m_removedCars.Count - 1];
				m_removedCars.RemoveAt(m_removedCars.Count - 1);
				m_cars[ix] = carData;
				return new CarHandle(ix);
			}
			else
			{
				m_cars.Add(carData);
				return new CarHandle(m_cars.Count-1);
			}
		}
		public void RemoveCar(ref CarHandle handle)
		{
			if (m_cars.Count > handle.ID && m_cars[handle.ID].Size != -1)
			{
				
				// remove from list if it is the last car in list
				if (handle.ID == m_cars.Count - 1)
				{
					m_cars.RemoveAt(m_cars.Count - 1);
				}
				else
				{
					// if we remove this item from the list, it would invalidate 
					// all handles after this index, so we just remember that we 
					// can reuse this slot
					m_removedCars.Add(handle.ID);
					m_cars[handle.ID] = new CarData() { Size = -1, Speed = -1 };
				}
			}
			// invalidate the handle so it cannot be used again
			handle.m_id = -1;
		}
		public int GetSize(CarHandle handle)
		{
			// TODO: add error checking!
			return m_cars[handle.ID].Size;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			CarManager manager = new CarManager();
			var car1 = manager.CreateCar(10, 20);
			var s1 = manager.GetSize(car1);
			System.Diagnostics.Debug.Assert(s1 == 20);
			var car2 = manager.CreateCar(30, 40);
			var s2 = manager.GetSize(car2);
			System.Diagnostics.Debug.Assert(s2 == 40);
			manager.RemoveCar(ref car1);
			System.Diagnostics.Debug.Assert(car1.ID == -1);
			s2 = manager.GetSize(car2);
			var car3 = manager.CreateCar(50, 60);
			var s3 = manager.GetSize(car3);
			System.Diagnostics.Debug.Assert(s3 == 60);
		}
	}
