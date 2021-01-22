    namespace ConsoleApplication1
    {
        using System;
        using System.Xml;
    
        class Program
        {
            static void Main( string[] args )
            {
                const string xml = @"
    <root>
        <funds>
            <fund name='A' ITEM0='7%' ITEM1='8%' ITEM2='9%' ITEM3='10%' ITEM4='11%' ITEM5='' /> 
            <fund name='B' ITEM0='11%' ITEM1='11%' ITEM2='13%' ITEM3='14%' ITEM4='16%' ITEM5='' /> 
            <fund name='C' ITEM0='' ITEM1='' ITEM2='' ITEM3='' ITEM4='' ITEM5='' /> 
            <fund name='D' ITEM0='7%' ITEM1='8%' ITEM2='9%' ITEM3='10%' ITEM4='11%' ITEM5='' /> 
            <fund name='E' ITEM0='2%' ITEM1='3%' ITEM2='3%' ITEM3='5%' ITEM4='5%' ITEM5='' /> 
            <fund name='F' ITEM0='' ITEM1='' ITEM2='' ITEM3='' ITEM4='' ITEM5='' /> 
            <fund name='G' ITEM0='3%' ITEM1='3%' ITEM2='3%' ITEM3='5%' ITEM4='5%' ITEM5='' /> 
        </funds>
        <ToAppend>
            <append name='A' ITEM='10' />
            <append name='B' ITEM='15' />
            <append name='C' ITEM='20' />
            <append name='D' ITEM='20' />
            <append name='E' ITEM='15' />
            <append name='F' ITEM='10' />
            <append name='G' ITEM='10' />
        </ToAppend>
    </root>
    ";
                // XPath that finds all "funds/fund" nodes that have a "name" attribute with the value "{0}".
                const string xpathTarget = @"//funds/fund[@name='{0}']";
    
                // XPath that finds all "ToAppend/append" nodes that have a "name" and "ITEM" attribute.
                const string xpathSourceNodes = @"//ToAppend/append[@name and @ITEM]";
    
                var doc = new XmlDocument();
                doc.LoadXml( xml );
    
                foreach ( XmlNode sourceNode in doc.SelectNodes( xpathSourceNodes ) )
                {
                    string name = sourceNode.Attributes[ "name" ].Value;
                    string item = sourceNode.Attributes[ "ITEM" ].Value;
    
                    XmlNode targetNode = doc.SelectSingleNode( String.Format( xpathTarget, name ) );
    
                    if ( null != targetNode )
                    {
                        XmlAttribute newAttribute = doc.CreateAttribute( "ITEM6" );
                        newAttribute.Value = item;
    
                        targetNode.Attributes.Append( newAttribute );
                    }
                }
            }
        }
    }
