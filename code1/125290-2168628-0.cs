    class Form1 : Form {
      private Button[] _buttons;
      public Form1(int count) { 
        _buttons = new Button[count];
        for ( int i = 0; i < count; i++ ) {
          var b = new Button();
          b.Text = "Button" + i.ToString()
          b.Click += new EventHandler(OnButtonClick);
          _buttons[i] = b;
        }
      }
      private void OnButtonClick(object sender, EventArgs e) {
        var whichButton = (Button)sender;
        ...
      }
    }
   
