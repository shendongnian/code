    [STAThread]
    static void Main(string[] args)
    {
        System.Type t = System.Type.GetTypeFromProgID("VisualStudio.DTE.8.0", true);
        DTE2 dte = (EnvDTE80.DTE2)System.Activator.CreateInstance(t, true);
    
        // See http://msdn.microsoft.com/en-us/library/ms228772.aspx for the
        // code for MessageFilter - just paste it in.
        MessageFilter.Register();
             
        dte.DoStuff();
        dte.Quit();
    }
    
    public class MessageFilter : IOleMessageFilter
    {
       ... Continues at http://msdn.microsoft.com/en-us/library/ms228772.aspx
