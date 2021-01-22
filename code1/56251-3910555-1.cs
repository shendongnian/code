    private List<StockSymbolResult> GetDistinctSymbolList( List<ICommonFields> l )
        		{
        			var DistinctList = (
        					from a
        					in l
        					orderby a.Symbol
        					select new
        					{
        						a.Symbol,
        						a.StockID
        					} ).Distinct();
        
        			StockSymbolResult ssr;
        			List<StockSymbolResult> rl = new List<StockSymbolResult>();
        			foreach ( var i in DistinctList )
        			{
                                    // Symbol is a string and StockID is an int.
        				ssr = new StockSymbolResult( i.Symbol, i.StockID );
        				rl.Add( ssr );
        			}
        
        			return rl;
        		}
