    XElement xml = new XElement("States",
      from s in LinqUtils.GetTable<State>()
      from cy in s.Counties
      from c in cy.Cities
      where c.Name.StartsWith("Y")
      group new { cy, c } by s into gs
      let s = gs.Key
      orderby s.Code 
      select new XElement("State",
        new XAttribute("Code", s.Code),
        new XAttribute("Name", s.Name),
        from g in gs
        group g.c by g.cy into gcy
        let cy = gcy.Key
        orderby cy.Name
        select new XElement("County",
          new XAttribute("Name", cy.Name),
          from c in gcy
          orderby c.Name
          select new XElement("City",
            new XAttribute("Name", c.Name)
          )
        )
      )
    );
