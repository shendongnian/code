    public partial class UI : Form
    {
      public UI(yourParameters[])
      {
        InitializeComponent();
        FatherControl.PostConstructor(yourParameters[]);
      }
    }
