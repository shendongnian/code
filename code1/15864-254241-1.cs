    class MyForm : Form
    {
      public Rectangle GetScreen()
      {
        return Screen.FromControl(this).Bounds;
      }
    }
