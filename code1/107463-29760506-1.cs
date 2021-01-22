    public partial class FatherControl : UserControl
    {
      public FatherControl()
      {
        InitializeComponent();
      }
      
      public void PostConstructor(YourParameters[])
      {
          ChildControl.PostConstructor(YourParameters[])
          //setting parameters/fillingdata into form
      }
    }
