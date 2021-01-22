            List<Section> sections = new List<Section>();
            sections.Add(new Section { SectionId = 1, ParentSectionId = 0, Name ="S1" });
            sections.Add(new Section { SectionId = 2, ParentSectionId = 1, Name = "S2" });
            sections.Add(new Section { SectionId = 3, ParentSectionId = 1, Name ="S3" });
            sections.Add(new Section { SectionId = 4, ParentSectionId = 2, Name ="S4" });
            sections.Add(new Section { SectionId = 5, ParentSectionId = 2, Name ="S5" });
            var result = sections.GroupJoin(sections, p => p.SectionId, chld => chld.ParentSectionId, (p, chld) => new { Parent = p, Children = chld })
                               .Where(g => g.Children.Any())
                               .Select(g => g.Parent);
