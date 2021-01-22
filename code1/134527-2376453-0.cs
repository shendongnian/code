    string[] propNames = new[] { "Prop1", "Prop2" };
    var props = (from n in xml.Elements()
                 where propNames.Contains(n.Name)
                 select new { n.Name, n.Value })
                .ToLookup(e => e.Name, e => e.Value);
    if (props.Contains("Prop1")) { ... }
    if (props.Contains("Prop2")) { ... }
    // etc.
