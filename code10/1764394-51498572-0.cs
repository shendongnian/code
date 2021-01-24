    string s = @"Trade Info
    
    NE62 -- NE62
    
    Symbol      Side        Quantity        Avg Price       ClientAcct      
    
    ESU8        BUY     100     2809.2500       35199008        
    FLT.V       SELL        15,000      1.7040      tB324aV     
    TRST.TO     SELL        4,850       7.1500      tB324aVV        
    YGR.TO      SELL        5,200       5.3806      tB324aV";
    
    var data = s.Split(new char[] { '\r','\n'},StringSplitOptions.RemoveEmptyEntries)
    .SkipWhile(x => !x.StartsWith("Symbol"))
    .Skip(1)
    .Select(line => line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
    .Select(d => new {
    	Symbol = d[0],
    	Side = d[1],
    	Quantity = int.Parse(d[2].Replace(",","")),
    	AvgPrice = decimal.Parse(d[3]),
    	ClientAcct = d[4]
    });
    
    yourDataGridView.DataSource = data.ToList();
