    public static class SerializeStatic
    {
    	public static bool Serialize(Type staticClass, string fileName)
    	{
    		XmlTextWriter xmlWriter = null;
    
    		try
    		{
    			FieldInfo[] fieldArray = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
    
    			xmlWriter = new XmlTextWriter(fileName, null);
    
    			xmlWriter.Formatting = Formatting.Indented;
    
    			xmlWriter.WriteStartDocument();
    			xmlWriter.WriteStartElement(staticClass.Name);
    
    			foreach (FieldInfo fieldInfo in fieldArray)
    			{
    				if (fieldInfo.Name == "db")
    					continue;
    
    				if (fieldInfo.IsNotSerialized)
    					continue;
    
    				string name = fieldInfo.Name;
    				string value = null;
    				object fieldObject = fieldInfo.GetValue(null);
    
    				if (fieldObject != null)
    				{
    					TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldInfo.FieldType);
    					value = typeConverter.ConvertToString(fieldObject);
    				}
    
    				xmlWriter.WriteStartElement(name);
    				xmlWriter.WriteString(value);
    				xmlWriter.WriteEndElement();
    			}
    
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
    
    	public static bool Deserialize(Type staticClass, string fileName)
    	{
    		XmlReader xmlReader = null;
    
    		try
    		{
    			FieldInfo[] fieldArray = staticClass.GetFields(BindingFlags.Static | BindingFlags.Public);
    			string currentElement = null;
    			xmlReader = new XmlTextReader(fileName);
    
    			xmlReader.Read();
    
    			while (xmlReader.Read())
    			{
    				if (xmlReader.NodeType == XmlNodeType.Element)
    				{
    					currentElement = xmlReader.Name;
    
    					continue;
    				}
    
    				if (xmlReader.NodeType != XmlNodeType.Text)
    					continue;
    
    				foreach (FieldInfo fieldInfo in fieldArray)
    				{
    					if (fieldInfo.Name == "db")
    						continue;
    
    					if (fieldInfo.IsNotSerialized)
    						continue;
    
    					if (fieldInfo.Name == currentElement)
    					{
    						TypeConverter typeConverter = TypeDescriptor.GetConverter(fieldInfo.FieldType);
    						object value = typeConverter.ConvertFromString(xmlReader.Value);
    
    						fieldInfo.SetValue(null, value);
    					}
    				}
    			}
    
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
    }
