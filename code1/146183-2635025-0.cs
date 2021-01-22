    // Get the PIA assemby name, using the GUID of the typlib
    string asmName;
    string asmCodeBase;
    var conv = new System.Runtime.InteropServices.TypeLibConverter();
    conv.GetPrimaryInteropAssembly(new Guid("00062FFF-0000-0000-C000-000000000046"), 9, 3, 0, out asmName, out asmCodeBase);
    // Load the PIA, and get the interface type
    var assembly = System.Reflection.Assembly.Load(asmName);
    var type = assembly.GetType("Microsoft.Office.Interop.Outlook.Application");
    // Get the coclass
    var coClassAttr = (System.Runtime.InteropServices.CoClassAttribute)
        type.GetCustomAttributes(typeof(System.Runtime.InteropServices.CoClassAttribute), false)[0];
    var coClass = coClassAttr.CoClass;
    // Instantiate the coclass
    var app = Activator.CreateInstance(coClassAttr.CoClass);
    
    // If needed, the CLSID is also available:
    var clsid = coClass.GUID;
