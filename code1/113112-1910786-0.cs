    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Reflection;
    
    namespace MetaDataTest
    {
        class Program
        {
            static void Main(string[] args)
            {
    			MetadataTypeAttribute[] metadataTypes = typeof(MyTestClass).GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().ToArray();
    			MetadataTypeAttribute metadata = metadataTypes.FirstOrDefault();
    			
				if (metadata != null)
				{
					PropertyInfo[] properties = metadata.MetadataClassType.GetProperties();
					foreach (PropertyInfo propertyInfo in properties)
					{
						Console.WriteLine(Attribute.IsDefined(propertyInfo, typeof(MyAttribute)));
						Console.WriteLine(propertyInfo.IsDefined(typeof(MyAttribute), true));
						Console.WriteLine(propertyInfo.GetCustomAttributes(true).Length);
						RequiredAttribute attrib = (RequiredAttribute)propertyInfo.GetCustomAttributes(typeof(RequiredAttribute), true)[0];
						Console.WriteLine(attrib.ErrorMessage);
					}
				
					// Results:
					// True
					// True
					// 2
					// MyField is Required
				}
        	    Console.ReadLine();
	        }
	    }
	    [MetadataType(typeof(MyMeta))]
	    public partial class MyTestClass
	    {
        	public string MyField { get; set; }
	    }
	    public class MyMeta
	    {
	        [MyAttribute()]
			[Required(ErrorMessage="MyField is Required")]
	        public string MyField { get; set; }
	    }
	    [AttributeUsage(AttributeTargets.All)]
	    public class MyAttribute : System.Attribute
	    {
	    }
	}
