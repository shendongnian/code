    class MyForm : Form
    {
      public Screen GetScreen()
      {
        return Screen.FromControl(this);
      }
    }
