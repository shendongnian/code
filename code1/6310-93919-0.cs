    public static bool IsReservedKeyWord(string identifier)
            {
                Microsoft.CSharp.CSharpCodeProvider csharpProvider = new Microsoft.CSharp.CSharpCodeProvider();
                return csharpProvider.IsValidIdentifier(identifier);
            }
