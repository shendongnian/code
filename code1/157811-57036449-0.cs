`
using System;
using System.Windows;
using System.Windows.Input;
public partial class NewView : UserControl
    {
    public NewView()
        {
            this.RemoveHandler(KeyDownEvent, new KeyEventHandler(NewView_KeyDown)); 
            // im not sure if the above line is needed (or if the GC takes care of it
            // anyway) , im adding it just to be safe  
            this.AddHandler(KeyDownEvent, new KeyEventHandler(NewView_KeyDown), true);
            InitializeComponent();
        }
     //....
      private void NewView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                //your logic
            }
        }
    }
`
