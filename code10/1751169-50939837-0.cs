    using (var context = new Context())
    {
        var child = new ChildEntity();
        child.Parent = new TParentEntity();
        context.Add(child);
        context.SaveChanges();
        Console.WriteLine(child.ParentId); // ParentId == 1
        child.Parent = new TParentEntity();
        Console.WriteLine(child.ParentId); // ParentId == 1
        context.SaveChanges();
        Console.WriteLine(child.ParentId); // ParentId == 2
    }
