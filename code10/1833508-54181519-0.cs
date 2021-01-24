    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    
    		MainViewModel vm = new MainViewModel();
    		foreach(tank t in vm.ListOfTanks.ballast)
    		{
    			Console.WriteLine(t.ID);
    		}
    		
    		
    	}
    	
    	public class MainViewModel
    	{
    		public tanks ListOfTanks
    		{
    			get
    			{
    				string xmlContent = "<?xml version=\"1.0\" encoding=\"utf-16\"?><tanks xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">  <ballast><tank><ID>ksj</ID></tank>  </ballast></tanks>";
    				tanks allTanks = null;
    
    				XmlSerializer serializer = new XmlSerializer(typeof(tanks));
    
    				//if you have a xml file you can use serializer.Deserialize("yourFile.xml"); instead of the "in memory stream"
    
    				using (TextReader reader = new StringReader(xmlContent))
    				{
    					allTanks =(tanks)serializer.Deserialize(reader);
    				}
    				return allTanks;
    			}
    		}
    	}
    	
    	
    	public class tanks
    	{
    		public tanks()
    		{
    			ballast = new List<tank>();
    		}
    		public List<tank> ballast {get;set;} 
    	}
    	
    	
    	public class tank
    	{
    		public string ID {get;set;}
    	}
    }
