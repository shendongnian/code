    using System.Runtime.InteropServices;
    ...
    object obj = Marshal.GetActiveObject("EA.App");
    var eaApp = obj as EA.App;
    var myRepository = eaApp?.Repository;
