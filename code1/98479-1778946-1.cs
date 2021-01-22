    using System;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Xml;
    
    
    namespace MyApp
    {
    	public static class ExtensionMethods
    	{
    		public static XmlNode AppendNewElement(this XmlNode element, string name)
    		{
    			return AppendNewElement(element, name, null);
    		}
    		public static XmlNode AppendNewElement(this XmlNode element, string name, string value)
    		{
    			return AppendNewElement(element, name, value, null);
    		}
    		public static XmlNode AppendNewElement(this XmlNode element, string name, string value, params KeyValuePair<string, string>[] attributes)
    		{
    			XmlDocument doc = element.OwnerDocument ?? (XmlDocument)element;
    			XmlElement addedElement = doc.CreateElement(name);
    			
    			if (value != null)
    				addedElement.SetTextValue(value);
    
    			if (attributes != null)
    				foreach (var attribute in attributes)
    					addedElement.AppendNewAttribute(attribute.Key, attribute.Value);
    
    			element.AppendChild(addedElement);
    
    			return addedElement;
    		}
    		public static XmlNode AppendNewAttribute(this XmlNode element, string name, string value)
    		{
    			XmlAttribute attr = element.OwnerDocument.CreateAttribute(name);
    			attr.Value = value;
    			element.Attributes.Append(attr);
    			return element;
    		}
    	}
    }
    
    namespace MyApp.Forms
    {
    	public static class MessageBoxes
    	{
    		private static readonly string Caption = "MyApp v" + Application.ProductVersion;
    
    		public static void Alert(MessageBoxIcon icon, params object[] args)
    		{
    			MessageBox.Show(GetMessage(args), Caption, MessageBoxButtons.OK, icon);
    		}
    		public static bool YesNo(MessageBoxIcon icon, params object[] args)
    		{
    			return MessageBox.Show(GetMessage(args), Caption, MessageBoxButtons.YesNo, icon) == DialogResult.Yes;
    		}
    
    		private static string GetMessage(object[] args)
    		{
    			if (args.Length == 1)
    			{
    				return args[0].ToString();
    			}
    			else
    			{
    				var messegeArgs = new object[args.Length - 1];
    				Array.Copy(args, 1, messegeArgs, 0, messegeArgs.Length);
    				return string.Format(args[0] as string, messegeArgs);
    			}
    
    		}
    	}
    }
