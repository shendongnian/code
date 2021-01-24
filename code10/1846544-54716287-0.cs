    var str = @"<Monthly>
            <Totals Month='1' Year='2019'><Total>698560</Total><Distinct>103798</Distinct></Totals>
            <Totals Month='12' Year='2018'><Total>556091</Total><Distinct>90550</Distinct></Totals>
            <Totals Month='11' Year='2018'><Total>638932</Total><Distinct>100398</Distinct></Totals>
            <Totals Month='10' Year='2018'><Total>721583</Total><Distinct>106044</Distinct></Totals>
            <Totals Month='9' Year='2018'><Total>620371</Total><Distinct>97455</Distinct></Totals>
        </Monthly>";
    	
    	var root =  XElement.Parse(str);
    	var result = root.Elements("Totals")
                         .OrderBy(e => int.Parse(e.Attribute("Year").Value))
                         .ThenBy(e => int.Parse(e.Attribute("Month").Value));
