    <%@ Page Language="C#" %>
    <%@ Import Namespace="System.Collections.Generic" %>
    <%@ Import Namespace="System.Reflection" %>
    <script runat="server">
    void Page_Load(Object sender, EventArgs e)
    {
        List<string> assemblyNames = GetLoadedAssemblyNames(false);
        StringBuilder sb = new StringBuilder();
        foreach (string ass in assemblyNames)
        {
            sb.AppendFormat("{0}\n", ass);
        }
        this.Results.Text = sb.ToString();
    }
    private static List<string> GetLoadedAssemblyNames(bool hideSystem)
    {
        List<string> names = new List<string>();
        foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
        {
            string name = a.GetName().FullName;
            if (hideSystem && (name.StartsWith("System.") || name.StartsWith("Microsoft.")))
            {
                continue;
            }
            names.Add(name);
        }
        names.Sort();
        return names;
    }
    </script>
    <html>
    <body>
    <form id="form1" runat="server">
     <h1>Loaded Assemblies</h1>
     <p><asp:Literal runat="server" ID="AppName" /></p>
     <pre><asp:Literal runat="server" ID="Results" /></pre>
    </form>
    </body>
    </html>
