    [STAThread]
    static void Main() {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      if (DialogResult.OK == new LangForm().ShowDialog()) {
        Application.Run(new Form1());
      }
    }
