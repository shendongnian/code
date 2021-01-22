    var Cities = from s in LinqUtils.GetTable<State>()
                 from cy in s.Counties
                 from c in cy.Cities
                 where c.Name.StartsWith("Y")
                 select c;
    var States = Cities.Select(c => c.County.State).Distinct();
    var Counties = Cities.Select(c => c.County).Distinct();
    XElement xml = new XElement("States",
      from s in States
      orderby s.Code
      select new XElement("State",
        new XAttribute("Code", s.Code),
        new XAttribute("Name", s.Name),
        from cy in Counties
        where cy.StateCode == s.Code
        orderby cy.Name
        select new XElement("County",
          new XAttribute("Name", cy.Name),
          from c in Cities
          where c.CountyID == cy.ID
          orderby c.Name
          select new XElement("City",
            new XAttribute("Name", c.Name)
          )
        )
      )
    );
