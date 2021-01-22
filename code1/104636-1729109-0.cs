    class MyControl : UserControl
    {
         private MyButton button;
         button.ChangeStyle("Selected");
    }
    class MyButton : Button
    {
         private Color buttonColor;
         public void ChangeStyle(string styleName)
         {
              if (styleName == "Selected")
                  this.BackColor = buttonColor;
         }
         [Browsable(true)]
         [Category("Button style")]
         public Color ButtonColor
         {
              get { return buttonColor; }
              set { buttonColor = value; }
         }
    }
