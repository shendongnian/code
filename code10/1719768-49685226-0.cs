    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public interface IDataRecievable 
    {
    	object GetData();
    }
    
    public class PiSensor : IDataRecievable
    {
         public object GetData() {
    		 return (object)3.14m;
         }
    }
    
    public class StringSensor : IDataRecievable
    {
         public object GetData() {
    		 return (object)"Hello World";
         }
    }
    
    
    public class DataCollector
    {
    
       private List<IDataRecievable> sensors;
    
       private Dictionary<Type, object> sensorResults = new Dictionary<Type, object>();
        
       public DataCollector(IEnumerable<IDataRecievable> sensorsToPoll)
       {
    	   this.sensors = sensorsToPoll.ToList();
       }
    	
       public T GetResultFromSensor<T>(Type sensorType)
       {
          return (T)this.sensorResults[sensorType];
       }
    	
    	public void CollectData()
    	{
    		foreach (IDataRecievable sensor in this.sensors)
    		{
    			sensorResults[sensor.GetType()] = sensor.GetData();
    		}    		
    	}    
    }
    
    public class Program
    {    	
    	public static void Main()
    	{
    		List<IDataRecievable> sensors = new List<IDataRecievable>
    		{
    			new PiSensor(),
    			new StringSensor()
    		};    		
    		DataCollector dc = new DataCollector(sensors);    
    		dc.CollectData();    		
    		decimal pi = dc.GetResultFromSensor<decimal>(typeof(PiSensor));
    		string greeting = dc.GetResultFromSensor<string>(typeof(StringSensor));
    
    		Console.WriteLine(2 * pi);
    		Console.WriteLine(greeting);
    	}
    }
