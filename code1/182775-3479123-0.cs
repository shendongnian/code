    for (int segmentIndex = 0; segmentIndex < segments.Length; ++segmentIndex)
    {
        var p = new Panel() { ... };
        var innerContent = new LiteralControl("<p>Hello, World!</p>");
        p.Controls.Add(innerContent);
        holder.Controls.Add(p);
    }
    container.Controls.Add(holder);  
