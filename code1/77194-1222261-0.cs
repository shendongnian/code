    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Program
    {
    	static void Main()
    	{
    		String xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?>
    			<smartForm idCode=""customersMain"">
    			    <title>Customers Main222</title>
    			    <description>Generic customer form.</description>
    			    <area idCode=""generalData"" title=""General Data"">
    				<column>
    				    <group>
    					<field idCode=""anrede"">
    					    <label>Anrede</label>
    					</field>
    					<field idCode=""firstName"">
    					    <label>First Name</label>
    					</field>
    					<field idCode=""lastName"">
    					    <label>Last Name</label>
    					</field>
    				    </group>
    				</column>
    			    </area>
    			    <area idCode=""address"" title=""Address"">
    				<column>
    				    <group>
    					<field idCode=""street"">
    					    <label>Street</label>
    					</field>
    					<field idCode=""location"">
    					    <label>Location</label>
    					</field>
    					<field idCode=""zipCode"">
    					    <label>Zip Code</label>
    					</field>
    				    </group>
    				</column>
    			    </area>
    			</smartForm>";
    
    		XElement element = XElement.Parse(xml)
    			.Descendants()
    			.FirstOrDefault();
    	}
    }
