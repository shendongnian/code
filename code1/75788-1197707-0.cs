    namespace Entities
    {
	public interface IResultEntity
	{
	}
	
	public class LifeEntity : IResultEntity
	{
		public override string ToString()
		{
			return("I'm a Life entity");
		}
	}
	
	public class PropertyEntity : IResultEntity
	{
		public override string ToString()
		{
			return("I'm a Property Entity");
		}
	}
	
	public class CreditCardEntity : IResultEntity
	{
		public override string ToString()
		{
			return("I'm a CreditCard Entity ");
		}
	}
	
	public class DisabilityEntity : IResultEntity
	{
		public override string ToString()
		{
			return("I'm a Disability Entity");
		}
	}
}
    	public static Entities.IResultEntity GetEntity(string entityTypeName,string fileName)
	{
	    XDocument  doc = XDocument.Load(fileName);
		XElement element = doc.Element("TypeMappings").Elements("TypeMapping")
								   .SingleOrDefault(x => x.Attribute("name").Value == entityTypeName);        
				
		if(element == null)
		{
			throw new InvalidOperationException("No type mapping found for " + entityTypeName);
		}	
		string typeName = element.Attribute("type").Value;
		Type type = Type.GetType(typeName);
		Entities.IResultEntity resultEntity = Activator.CreateInstance(type) as Entities.IResultEntity;
		if(resultEntity == null)
		{
			throw new InvalidOperationException("type mapping for " + entityTypeName +  " is invalid");
		}
		return resultEntity;
	}
        
        public static void Main()
	{
		try
		{
			Entities.IResultEntity result = GetEntity("life", @"c:\temp\entities.xml");
			Console.WriteLine(result);
			
			 result = GetEntity("property", @"c:\temp\entities.xml");
			Console.WriteLine(result);
			
			 result = GetEntity("disability", @"c:\temp\entities.xml");
			Console.WriteLine(result);			
			
			 result = GetEntity("creditcard", @"c:\temp\entities.xml");
			Console.WriteLine(result);			
			
			 result = GetEntity("foo", @"c:\temp\entities.xml");
			Console.WriteLine(result);		
			
		}
    }
