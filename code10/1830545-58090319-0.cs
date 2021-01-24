// using System.Diagnostics.CodeAnalysis;
[return: NotNullIfNotNull("s")]
string? Foo(string? s)
{
    // Do something with s.
    return s;
}
