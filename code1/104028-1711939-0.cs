    [EditorAttribute(typeof(MultilineStringEditor), 
                     typeof(System.Drawing.Design.UITypeEditor))]  
    public string Instructions
    {
       get
       {
          return TextBox1.Text;
       }
       set
       {
          TextBox1.Text = value;
       }
    }
