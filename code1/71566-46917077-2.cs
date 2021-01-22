    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace HQ.Util.General
    {
    	public class XmlSerializerHelper
    	{
    		private static readonly Dictionary<Type, XmlSerializer> _dictTypeToSerializer = new Dictionary<Type, XmlSerializer>();
    
    		public static XmlSerializer GetSerializer(Type type)
    		{
    			lock (_dictTypeToSerializer)
    			{
    				XmlSerializer serializer;
    				if (! _dictTypeToSerializer.TryGetValue(type, out serializer))
    				{
    					var importer = new XmlReflectionImporter();
    					var mapping = importer.ImportTypeMapping(type, null, null);
    					serializer = new XmlSerializer(mapping);
    					return _dictTypeToSerializer[type] = serializer;
    				}
    
    				return serializer;
    			}
    		}
    	}
    }
