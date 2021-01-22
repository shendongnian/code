    dic
     .Select(kvp => new { Control = this.FindControl(kvp.Key), Visible = kvp.Value })
     .Where(i => i.Control != null)
     .ToList()
     .ForEach(p => { p.Control.Visible = p.Visible; });
