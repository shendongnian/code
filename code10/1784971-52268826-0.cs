    int hit = r.Next(1, 5);
    if (hit == 1) {
        // do a thing
    }
    // using newer string interpolation, implicit hit.ToString()
    Console.WriteLine($"Hit was {hit}");
    
    // using old format, implicit hit.ToString()
    Console.WriteLine("Hit was {0}", hit);
    // using old format, explicit hit.ToString()
    Console.WriteLine("Hit was {0}", hit.ToString());
