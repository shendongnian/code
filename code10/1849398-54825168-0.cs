class TestClass
{
    public string var1 { get; set; }
    public string var2 { get; set; }
    public string var3 { get; set; }
    
    public TestClass(string var1, string var2, string var3) : base()
    {
        var param = new { var1, var2, var3 };
        PropertyInfo[] info = this.GetType().GetProperties();
        
        foreach (PropertyInfo infos in info) {
            foreach (PropertyInfo paramInfo in param.GetType().GetProperties()) {
                if (infos.Name == paramInfo.Name) {
                    infos.SetValue(this, paramInfo.GetValue(param, null));
                }
            }
        }
    }
}
   This basically loops through the properties and check's whether the name equals the parameter name, which have been stored in a temporary array (you can't get the parameter value with reflection), and assigns it if they match.
Note: I do not recommend assigning properties like that, but for the sake of proof that it's possible I came up with this.
