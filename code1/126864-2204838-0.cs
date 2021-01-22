    object word;
    try
    {
        word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    }
    catch (COMException)
    {
        Type type = Type.GetTypeFromProgID("Word.Application");
        word = System.Activator.CreateInstance(type);
    }
