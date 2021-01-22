    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace HQ.Util.General
    {
    	/// <summary>
    	/// Save by default as User Data Preferences
    	/// </summary>
    	public class XmlPersistence
    	{
    		// ******************************************************************
    		public static void Save<T>(T obj, string path = null) where T : class
    		{
    			if (path == null)
    			{
    				path = GetDefaultPath(typeof(T));
    			}
    
    			var serializer = new XmlSerializer(typeof(T));
    			using (TextWriter writer = new StreamWriter(path))
    			{
    				serializer.Serialize(writer, obj);
    				writer.Close();
    			}
    		}
    
    		// ******************************************************************
    		public static T Load<T>(string path = null,
    			Action<object, XmlNodeEventArgs> actionUnknownNode = null,
    			Action<object, XmlAttributeEventArgs> actionUnknownAttribute = null) where T : class
    		{
    			T obj = null;
    
    			if (path == null)
    			{
    				path = GetDefaultPath(typeof(T));
    			}
    
    			if (File.Exists(path))
    			{
    				var serializer = new XmlSerializer(typeof(T));
    
    				if (actionUnknownAttribute == null)
    				{
    					actionUnknownAttribute = UnknownAttribute;
    				}
    
    				if (actionUnknownNode == null)
    				{
    					actionUnknownNode = UnknownNode;
    				}
    
    				serializer.UnknownAttribute += new XmlAttributeEventHandler(actionUnknownAttribute);
    				serializer.UnknownNode += new XmlNodeEventHandler(actionUnknownNode);
    
    				using (var fs = new FileStream(path, FileMode.Open))
    				{
    					// Declares an object variable of the type to be deserialized.
    					// Uses the Deserialize method to restore the object's state 
    					// with data from the XML document. */
    					obj = (T)serializer.Deserialize(fs);
    				}
    			}
    
    			return obj;
    		}
    
    		// ******************************************************************
    		private static string GetDefaultPath(Type typeOfObjectToSerialize)
            {
    			return Path.Combine(AppInfo.AppDataFolder, typeOfObjectToSerialize.Name + ".xml");
    		}
    
    		// ******************************************************************
    		private static void UnknownAttribute(object sender, XmlAttributeEventArgs xmlAttributeEventArgs)
    		{
    			// Correction according to: https://stackoverflow.com/questions/42342875/xmlserializer-warns-about-unknown-nodes-attributes-when-deserializing-derived-ty/42407193#42407193
    			if (xmlAttributeEventArgs.Attr.Name == "xsi:type")
    			{
    
    			}
    			else
    			{
    				throw new XmlException("UnknownAttribute" + xmlAttributeEventArgs.ToString());
    			}
    		}
    
    		// ******************************************************************
    		private static void UnknownNode(object sender, XmlNodeEventArgs xmlNodeEventArgs)
    		{
    			// Correction according to: https://stackoverflow.com/questions/42342875/xmlserializer-warns-about-unknown-nodes-attributes-when-deserializing-derived-ty/42407193#42407193
    			if (xmlNodeEventArgs.Name == "xsi:type")
    			{
    
    			}
    			else
    			{
    				throw new XmlException("UnknownNode" + xmlNodeEventArgs.ToString());
    			}
    
    		}
    
    		// ******************************************************************
    
    
    
    	}
    }
