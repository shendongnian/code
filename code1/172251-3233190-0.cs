    string xml = "<top><SeatSeg><Num>9</Num></SeatSeg><SeatAssignment><Loc>032A</Loc></SeatAssignment><SeatSeg><Num>10</Num></SeatSeg><SeatAssignment><Loc>033A</Loc></SeatAssignment></top>";
    int seatNum = 10;
    XDocument xDoc = XDocument.Parse(xml);
    
    string seatLoc = (from seatSeg in xDoc.Element("top").Elements("SeatSeg")
    				  where seatSeg.Element("Num").Value == seatNum.ToString() 
    				  select seatSeg
    				 ).Single().ElementsBeforeSelf().Last().Element("Loc").Value;
    				 
    Console.WriteLine(seatLoc);
