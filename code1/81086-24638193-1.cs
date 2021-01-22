    public static class SerializeStatic
    {
    	public static bool Serialize(Type staticClass, string fileName)
    	{
    		XmlTextWriter xmlWriter = null;
    
    		try
    		{
    			xmlWriter = new XmlTextWriter(fileName, null);
    
    			xmlWriter.Formatting = Formatting.Indented;
    
    			xmlWriter.WriteStartDocument();
    
    			Serialize(staticClass, xmlWriter);
    
    			xmlWriter.WriteEndDocument();
    
    			return true;
    		}
    		catch (Exception ex)
    		{
    			System.Windows.Forms.MessageBox.Show(ex.ToString());
    
    			return false;
    		}
    		finally
    		{
    			if (xmlWriter != null)
    			{
    				xmlWriter.Flush();
    				xmlWriter.Close();
    			}
    		}
    	}
    
    	public static void Serialize(string name, object obj, XmlTextWriter xmlWriter)
    	{
    		Type type = obj.GetType();
    		XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
    		XmlAttributes xmlAttributes = new XmlAttributes();
    		xmlAttributes.XmlRoot = new XmlRootAttribute(name);
    		xmlAttributeOverrides.Add(type, xmlAttributes);
    		XmlSerializer xmlSerializer = new XmlSerializer(type, xmlAttributeOverrides);
    
    		xmlSerializer.Serialize(xmlWriter, obj);
    	}
    
    	public static bool Serialize(Type staticClass, XmlTextWriter xmlWriter)
    	{
    		FieldInfo[] fieldArray = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
    
    		xmlWriter.WriteStartElement(staticClass.Name);
    
    		foreach (FieldInfo fieldInfo in fieldArray)
    		{
    			if (fieldInfo.IsNotSerialized)
    				continue;
    
    			string fieldName = fieldInfo.Name;
    			string fieldValue = null;
    			Type fieldType = fieldInfo.FieldType;
    			object fieldObject = fieldInfo.GetValue(fieldType);
    
    			if (fieldObject != null)
    			{
    				if (fieldType.GetInterface("IDictionary") != null || fieldType.GetInterface("IList") != null)
    				{
    					Serialize(fieldName, fieldObject, xmlWriter);
    				}
    				else
    				{
    					TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldInfo.FieldType);
    					fieldValue = typeConverter.ConvertToString(fieldObject);
    
    					xmlWriter.WriteStartElement(fieldName);
    					xmlWriter.WriteString(fieldValue);
    					xmlWriter.WriteEndElement();
    				}
    			}
    		}
    
    		xmlWriter.WriteEndElement();
    
    		return true;
    	}
    
    	public static bool Deserialize(Type staticClass, string fileName)
    	{
    		XmlReader xmlReader = null;
    
    		try
    		{
    			xmlReader = new XmlTextReader(fileName);
    
    			Deserialize(staticClass, xmlReader);
    
    			return true;
    		}
    		catch (Exception ex)
    		{
    			System.Windows.Forms.MessageBox.Show(ex.ToString());
    
    			return false;
    		}
    		finally
    		{
    			if (xmlReader != null)
    			{
    				xmlReader.Close();
    				xmlReader = null;
    			}
    		}
    	}
    
    	public static object Deserialize(string name, Type type, XmlReader xmlReader)
    	{
    		XmlAttributeOverrides xmlAttributeOverrides = new XmlAttributeOverrides();
    		XmlAttributes xmlAttributes = new XmlAttributes();
    		xmlAttributes.XmlRoot = new XmlRootAttribute(name);
    		xmlAttributeOverrides.Add(type, xmlAttributes);
    		XmlSerializer xmlSerializer = new XmlSerializer(type, xmlAttributeOverrides);
    
    		return xmlSerializer.Deserialize(xmlReader);
    	}
    
    	public static bool Deserialize(Type staticClass, XmlReader xmlReader)
    	{
    		FieldInfo[] fieldArray = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
    		string currentElement = null;
    
    		while (xmlReader.Read())
    		{
    			if (xmlReader.NodeType == XmlNodeType.EndElement)
    				continue;
    
    			if (xmlReader.NodeType == XmlNodeType.Element)
    			{
    				currentElement = xmlReader.Name;
    			}
    
    			foreach (FieldInfo fieldInfo in fieldArray)
    			{
    				string fieldName = fieldInfo.Name;
    				Type fieldType = fieldInfo.FieldType;
    				object fieldObject = fieldInfo.GetValue(fieldType);
    
    				if (fieldInfo.IsNotSerialized)
    					continue;
    
    				if (fieldInfo.Name == currentElement)
    				{
    					if (typeof(IDictionary).IsAssignableFrom(fieldType) || typeof(IList).IsAssignableFrom(fieldType))
    					{
    						fieldObject = Deserialize(fieldName, fieldType, xmlReader);
    
    						fieldInfo.SetValueDirect(__makeref(fieldObject), fieldObject);
    					}
    					else if (xmlReader.NodeType == XmlNodeType.Text)
    					{
    						TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldType);
    						object value = typeConverter.ConvertFromString(xmlReader.Value);
    
    						fieldInfo.SetValue(fieldObject, value);
    					}
    				}
    			}
    		}
    
    		return true;
    	}
    }
