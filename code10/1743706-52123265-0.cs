    var hello = "Hello".AsSpan();
    var space = " ".AsSpan();
    var world = "World".AsSpan();
    // First allocate the buffer with the target size
    char[] buffer = new char[hello.Length + space.Length + world.Length];
    // "Convert" it to writable Span<char>
    var span = new Span<char>(buffer);
    // Then copy each span at the right position in the buffer
    int index = 0;
    hello.CopyTo(span.Slice(index, hello.Length));
    index += hello.Length;
    space.CopyTo(span.Slice(index, space.Length));
    index += space.Length;
    world.CopyTo(span.Slice(index, world.Length));
    // Finality get back the string
    string result = span.ToString();
