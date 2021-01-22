    public class MyUriParser : UriParser
    {
    private string actualScheme;
    public MyUriParser(string actualScheme)
    {
        Type type = this.GetType();
        FieldInfo fInfo = type.BaseType.GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
        fInfo.SetValue(this, GenericUriParserOptions.DontCompressPath);
        this.actualScheme = actualScheme.ToLowerInvariant();
    }
    protected override string GetComponents(Uri uri, UriComponents components, UriFormat format)
    {
        string result = base.GetComponents(uri, components, format);
        // Substitute our actual desired scheme in the string if it's in there. 
        if ((components & UriComponents.Scheme) != 0)
        {
            string registeredScheme = base.GetComponents(uri, UriComponents.Scheme, format);
            result = this.actualScheme + result.Substring(registeredScheme.Length);
        }
        return result;
    }}
 
