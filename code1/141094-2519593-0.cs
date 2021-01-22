public class MainForm : Form
{
    public MainForm()
    {
        Instance = this;
    }
    public static MainForm Instance { get; private set; }
    // Function to output results to main Listbox window        
    public void TextToBox(string aString)
    {
        // Place messages in Main Display list box window
        this.listBox1.Items.Insert(0, aString);
    }
}
public class Other
{
    public void AddTextToListBox()
    {
        MainForm.Instance.TextToBox("Test");
    }
}
