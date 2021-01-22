    var drag = _mouseDown
        .Select(args => args.EventArgs.GetPosition(canvas))
        .Zip(_mouseUp.Select(args => args.EventArgs.GetPosition(canvas)), 
            (p1, p2) => new { p1, p2 });
    drag.Subscribe(p1p2 => 
            Console.WriteLine(@"({0}:{1})({2}:{3})", 
                p1p2.p1.X, p1p2.p1.Y, p1p2.p2.X, p1p2.p2.Y));
