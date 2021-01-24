    // When retrieving an object from session state, cast it to 
    // the appropriate type.
    ArrayList stockPicks = (ArrayList)Session["StockPicks"];
    // Write the modified stock picks list back to session state.
    Session["StockPicks"] = stockPicks;
