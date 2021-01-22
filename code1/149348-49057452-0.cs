    using static System.ConsoleColor;
    ConsoleRenderer.RenderDocument(new Document().AddChildren(
        new Span(">>> Order: ") { Color = Cyan },
        new Span("Data") { Color = Gray },
        new Span("Parity") { Color = DarkGreen },
        new Span(" <<<") { Color = Cyan }
    ));
