    public partial class Form1 : Form
    {
    	public Form1()
    	{
    		InitializeComponent();
    		listBoxDisplay.DataSource = Values;
    	}
        // Here is our list of strings
    	BindingList<string> Values = new BindingList<string>();
    	private void buttonStore_Click(Object sender, EventArgs e)
    	{
            // We look at the value in the textbox and add it to list...
    		Values.Add((Values.Count + 1).ToString() + " - " +  textBoxValueToAdd.Text);
            // …and tell the ListBox to update itself from the list
    		listBoxDisplay.Refresh();
    	}
    }
