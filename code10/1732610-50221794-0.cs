    string str = @"
    <root>
    	<Emp>
    			<A.EMPLID>1</A.EMPLID>
    			<A.Phone>1234</A.Phone>
    	</Emp>
    	<Emp>
    			<A.EMPLID>2</A.EMPLID>
    			<A.Phone>1234</A.Phone>
    	</Emp>
    	<Emp>
    			<A.EMPLID>1</A.EMPLID>
    			<A.Phone>1234</A.Phone>
    	</Emp>
    	<Emp>
    			<A.EMPLID>3</A.EMPLID>
    	</Emp>
    </root>";
    
    var xml = XElement.Parse(str);
    int count = xml.Elements().GroupBy(x => x.Element("A.EMPLID").Value).Count();
    // count = 3
