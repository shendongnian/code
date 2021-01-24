    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Xml;
    
    namespace ConsoleApp1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			string x = @"<?xml version=""1.0"" encoding=""UTF-8""?>
    <ServiceResponse xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""https://xxxxxxxxxxxx"">
    	<responseCode>SUCCESS</responseCode>
    	<count>xxx</count>
    	<hasMoreRecords>true</hasMoreRecords>
    	<lastId>xxxxxxxx</lastId>
    	<data>
    		<name>XXXX</name>
    		<parentTagId>xxxxxxxx</parentTagId>
    		<created>xxxxxxxx</created>
    		<modified>xxxxxxxx</modified>
    		<ruleText>xxxxxxxx</ruleText>
    		<ruleType>xxxxxxxx</ruleType>
    		<srcAssetGroupId>xxxxxxxx</srcAssetGroupId>
    		<srcBusinessUnitId>xxxxxxxx</srcBusinessUnitId>
    	</data>
    	<data>
    		<name>YYYY</name>
    		<parentTagId>pti</parentTagId>
    		<created>c</created>
    		<modified>m</modified>
    		<ruleText>rt</ruleText>
    		<ruleType>rty</ruleType>
    		<srcAssetGroupId>a</srcAssetGroupId>
    		<srcBusinessUnitId>b</srcBusinessUnitId>
    	</data>
    </ServiceResponse>";
    
    			string q = @"<?xml version=""1.0"" encoding=""UTF-8"" ?><ServiceRequest><filters><Criteria field=""name"" operator=""CONTAINS"">XXX</Criteria></filters></ServiceRequest>";
    			XDocument qd = XDocument.Parse(q);
    
    			List<string> fieldNames = new List<string>();
    			List<string> operators = new List<string>();
    			List<string> values = new List<string>();
    
    			foreach(XElement criterion in qd.Descendants("Criteria"))
    			{
    				fieldNames.Add(criterion.Attribute("field").Value);
    				operators.Add(criterion.Attribute("operator").Value);
    				values.Add(criterion.Value);
    			}
    
    			//TODO: write code to cope with anything other than exactly 1 criterion.
    			//TODO: write code for operators other than "contains".
    
    			// Construct an XPath query expression:
    			string xq = $"//{fieldNames[0]}[contains(text(), '{values[0]}')]/..";
    
    			XmlDocument xd = new XmlDocument();
    			xd.LoadXml(x);
    
    			foreach (XmlNode n in xd.SelectNodes(xq))
    			{
    				Console.WriteLine(n.InnerXml);
    			}
    
    			Console.ReadLine();
    
    		}
    	}
    }
