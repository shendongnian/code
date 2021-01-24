    //assuming that Instructions is a DbSet<Instruction>
    using (var context = new MyContext() ) {
        context.Instructions.Add(
            new instruction {
                Property = new Property {
                    Correspondence = new Address {}
                }
            });
    }
    using (var context = new MyContext() ) {
        var c = context.Instructions.First();
        console.WriteLine($"{c.Id}, {c?.Property.Id}, {c?.Property?.Correspondence.Id}");
    });
    
