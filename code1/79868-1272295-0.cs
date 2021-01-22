    using System;
    using System.IO;
    using System.Collections.ObjectModel;
    using System.Runtime.Serialization;
    
    class Program
    {
    	static void Main()
    	{
    		CarCollection cars = new CarCollection();
    		cars.Add(new Car { Make = "Ford", Model = "Mustang" });
    		cars.Add(new Car { Make = "Honda", Model = "Accord" });
    		cars.Add(new Car { Make = "Toyota", Model = "Tundra" });
    
    		using (MemoryStream memoryStream = new MemoryStream())
    		{
    			DataContractSerializer serializer 
    				= new DataContractSerializer(typeof(CarCollection));
    			serializer.WriteObject(memoryStream, cars);
    			memoryStream.Position = 0;
    
    			String xml = null;
    			using (StreamReader reader = new StreamReader(memoryStream))
    			{
    				xml = reader.ReadToEnd();
    				reader.Close();
    			}
    			memoryStream.Close();
    		}
    	}
    }
    
    [CollectionDataContract(Name = "cars")]
    public class CarCollection : Collection<Car> { }
    
    [DataContract(Name = "car")]
    public class Car
    {
    	[DataMember(Name = "make")]
    	public String Make { get; set; }
    
    	[DataMember(Name = "model")]
    	public String Model { get; set; }
    }
