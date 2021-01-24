    @using System;
    @using System.Collections.Generic;
    @using System.Linq;
    @using System.Xml.Linq;
    
    <div>
        @{
            String URLString = "https://api3.libcal.com/api_hours_grid.php?iid=4246&  format=xml&weeks=1&systemTime=0";
            XDocument xdoc = new XDocument();
            xdoc = XDocument.Load(URLString);
    
    
            var location = (from p in xdoc.Descendants("location")
                            from s in p.Descendants("week").Elements()
                            select new
                            {
                                CampusName = (string)p.Element("name"),
                                WeekD = (string)s.Element("date")
                            }).ToList();
    
    
            var result = location.GroupBy(x => x.CampusName)
                   .ToDictionary(grp => grp.Key, grp => grp.Select(x => x.WeekD));
    
    
            foreach (var item in result)
            {
                <h2>@item.Key</h2>
                foreach (var innerItem in item.Value)
                {
                    <p>@innerItem</p>
                }
            }
        }
    
    </div>
  
    
