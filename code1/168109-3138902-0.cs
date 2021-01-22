    using System;
    using System.Xml;
    
    namespace ConsoleApplication2
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string path = @"D:\stack.xml";
    			string[] result = ParseXmlFile(path, 2);
    		}
    
    		private static string[] ParseXmlFile(string path, int rollNo)
    		{
    			XmlReaderSettings xtrs = new XmlReaderSettings();
    			xtrs.IgnoreComments = true;
    			xtrs.IgnoreProcessingInstructions = true;
    			xtrs.IgnoreWhitespace = true;
    
    			using (XmlReader xtr = XmlReader.Create(path, xtrs))
    			{
    				while (xtr.Read())
    				{
    					if (xtr.Name == "students")
    					{
    						return ParseStudent(xtr, rollNo);
    					}
    				}
    			}
    
    			throw new ArgumentException();
    		}
    
    		private static string[] ParseStudent(XmlReader reader, int rollNo)
    		{
    			while (reader.Read())
    			{
    				if (reader.Name == "student")
    				{
    					string _name = string.Empty;
    					string _grade = string.Empty;
    					int _rollNo = 0;
    
    					while (reader.MoveToNextAttribute())
    					{
    						switch (reader.Name)
    						{
    							case "Name":
    								_name = reader.Value;
    								break;
    							case "Grade":
    								_grade = reader.Value;
    								break;
    							case "rollNo":
    								_rollNo = Convert.ToInt32(reader.Value);
    								break;
    							default:
    								break;
    						}
    					}
    
    					if (_rollNo == rollNo)
    						return new string[] { _name, _grade };
    				}
    			}
    			throw new ArgumentException();
    		}
    	}
    }
