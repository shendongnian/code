    XElement xml = new XElement("States",
      from s in LinqUtils.GetTable<State>()
      let counties = from cy in s.Counties
                     let cities = from c in cy.Cities
                                  where c.Name.StartsWith("Y")
                                  orderby c.Name
                                  select new XElement("City",
                                    new XAttribute("Name", c.Name)
                                  )
                     where cities.Any()
                     orderby cy.Name
                     select new XElement("County",
                       new XAttribute("Name", cy.Name),
                       cities          
                     )
      where counties.Any()
      orderby s.Code 
      select new XElement("State",
        new XAttribute("Code", s.Code),
        new XAttribute("Name", s.Name),
        counties
      )
    );
