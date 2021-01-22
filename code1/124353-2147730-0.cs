    public static class OmfgUpdater
    {
      private static MyForm _mainForm;
      public static void RegisterForm(MyForm form)
      {
        _mainForm = form;
      }
    
      /*however this is done in your class*/
      internal void Update(Dictionary<string,string> updates)
      {
        _mainForm.Update(updates);
      }
    }
    
    public class MyForm : Form
    {
    
      public MyForm()
      {
        OmfgUpdater.RegisterForm(this);
      }
    
      public void Update(Dictionary<string,string> updates)
      {
        /* oh look you got updates do something with them */
      }
    }
