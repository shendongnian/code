    class A : Form
    {
      public A()
      {
        Initialize();
        HookEvents();
      }
    
      private void HookEvents()
      {
        dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
      }
    }
