    public class Form1 : Form
    {
    public Form1()
    {
        InitializeComponents(); // or whatever that method is called :)
        this.button.Click += new RoutedEventHandler(buttonClick);
    }
    
    private void buttonClick(object sender, EventArgs e)
    {
        this.Close();
    }
    }
