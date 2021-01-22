class Program
{
    public static MainForm MainFormInstance;
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        MainFormInstance = new MainForm();
        Application.Run(MainFormInstance);
    }
}
public class Other
{
    public void AddTextToListBox()
    {
        Program.MainFormInstance.TextToBox("Test");
    }
}
