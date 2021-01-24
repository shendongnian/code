    IEnumerable<ParentBLL> parents = grandChildren
                           .Select(gc => gc.Parent)
                           .Distinct()
                           .Pipe(p => p.GrandChildren = grandChildren.Where(gc => gc.Parent.ID == p.ID).ToList());
    IEnumerable<GrandParentBLL> grandparents = parents
                                .Select(p => p.GrandParent).Distinct()
                                .Pipe( gp => gp.Parents = parents.Where(p => p.GrandParent.ID == gp.ID).ToList());
