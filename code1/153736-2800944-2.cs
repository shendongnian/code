    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
      }
      private void Form1_Load(object sender, EventArgs e)
      {
        this.ControlBox = false;
        this.FormBorderStyle = FormBorderStyle.None;
        this.WindowState = FormWindowState.Maximized;
      }
      
      private void Form1_KeyDown(object sender, KeyEventArgs e)
      {
        //example of how to programmatically reverse the full-screen.
        //(You will have to add the event handler for KeyDown for this to work)
        //if you are using a Key event handler, then you should set the 
        //form's KeyPreview property to true so that it works when focus
        //is on a child control.
        if (e.KeyCode == Keys.Escape)
        {
          this.ControlBox = true;
          this.FormBorderStyle = FormBorderStyle.Sizable;
          this.WindowState = FormWindowState.Normal;
        }
      }
    }
