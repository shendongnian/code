    using System;
    using System.Xml.Serialization;
    using System.IO;
    
    public class Main
    {
    	[XmlElement("Person")]
    	public Person[] People { get; set; }
    }
    
    public class Person
    {
    	public string Name { get; set; }
    
    	public string Surname { get; set; }
    
    	public string Gender { get; set; }
    
    	public int OrderNum { get; set; }
    
    	public string BirthDate { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		var xmlString = @"<Main>
    						<Person>
    							<Name>Božena</Name>
    							<Surname>Němcová</Surname>
    							<Gender>Female</Gender>
    							<OrderNum>18</OrderNum>
    							<BirthDate>04.02.1820</BirthDate>
    						</Person>
    						<Person>
    							<Name>Jan</Name>
    							<Surname>Žižka</Surname>
    							<Gender>Male</Gender>
    							<OrderNum>7</OrderNum>
    							<BirthDate>19.09.1360</BirthDate>
    						</Person>
    						<Person>
    							<Name>Che</Name>
    							<Surname>Guevara</Surname>
    							<Gender>Male</Gender>
    							<OrderNum>27</OrderNum>
    							<BirthDate>14.06.1928</BirthDate>
    						</Person>
    						<Person>
    							<Name>Antonie</Name>
    							<Surname>de Saint-Exupéry</Surname>
    							<Gender>Male</Gender>
    							<OrderNum>15</OrderNum>
    							<BirthDate>29.06.1900</BirthDate>
    						</Person>
    					</Main>";
    		var serializer = new XmlSerializer(typeof (Main));
    		Main main = null;
    		using (var reader = new StringReader(xmlString))
    		{
    			main = (Main)serializer.Deserialize(reader);
    		}
    		
    		if (main == null)
    		{
    			return;	
    		}
    		
    		Console.WriteLine(main.People.Length);
    	}
    }
