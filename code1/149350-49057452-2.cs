    public static class Spans
    {
        public static Span Black(this string text) => new Span(text) { Color = ConsoleColor.Black };
        public static Span DarkBlue(this string text) => new Span(text) { Color = ConsoleColor.DarkBlue };
        public static Span DarkGreen(this string text) => new Span(text) { Color = ConsoleColor.DarkGreen };
        public static Span DarkCyan(this string text) => new Span(text) { Color = ConsoleColor.DarkCyan };
        public static Span DarkRed(this string text) => new Span(text) { Color = ConsoleColor.DarkRed };
        public static Span DarkMagenta(this string text) => new Span(text) { Color = ConsoleColor.DarkMagenta };
        public static Span DarkYellow(this string text) => new Span(text) { Color = ConsoleColor.DarkYellow };
        public static Span Gray(this string text) => new Span(text) { Color = ConsoleColor.Gray };
        public static Span DarkGray(this string text) => new Span(text) { Color = ConsoleColor.DarkGray };
        public static Span Blue(this string text) => new Span(text) { Color = ConsoleColor.Blue };
        public static Span Green(this string text) => new Span(text) { Color = ConsoleColor.Green };
        public static Span Cyan(this string text) => new Span(text) { Color = ConsoleColor.Cyan };
        public static Span Red(this string text) => new Span(text) { Color = ConsoleColor.Red };
        public static Span Magenta(this string text) => new Span(text) { Color = ConsoleColor.Magenta };
        public static Span Yellow(this string text) => new Span(text) { Color = ConsoleColor.Yellow };
        public static Span White(this string text) => new Span(text) { Color = ConsoleColor.White };
        public static void Render(object[] elements) => ConsoleRenderer.RenderDocument(new Document().AddChildren(elements));
    }
