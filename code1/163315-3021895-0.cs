    this.PerformancePanels = doc.Elements("PerformancePanel").Select(e =>
     {
         var control = (PerformancePanel)LoadControl(this.OfflineFactsheetPath
                                                    + (string)e.Attribute("page"));
    
    
    
         control.PerformanceFunds = e.Elements("FundGroup").ToDictionary(xx => (string)xx.Attribute("heading"),
                                                                         xx => xx.Elements("fund").Select(g =>
              {
                  Fund fund = new Fund
                                  {
                                      FundId = (int)g.Attribute("id"),
                                      CountryId = (string)g.Attribute("countryid"),
                                      FundIndex = (g.Attribute("index") == null)
                                      ? null : new Index
                                                   {
                                                       Id = (int)g.Attribute("index")
                                                   },
                                      FundNameAppend = (g.Attribute("append") == null)
                                         ? ""
                                         : (string)g.Attribute("append")
                                  };
                  return fund;
              }).ToList());
    
         return control;
     }).ToList();
