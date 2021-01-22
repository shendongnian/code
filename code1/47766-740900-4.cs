    public class EULAEventArgs : EventArgs
    {
      public string Signature { get; set; }
    }
    public class FormB : Form
    {
      public event EventHandler<EULAEventArgs> EULAAccepted;
      protected virtual void OnEULAAccepted(EULAEventArgs e)
      {
        if (EULAAccepted != null)
          EULAAccepted(this, e);
      }
 
      public void Button1_Clicked(...)
      {
        OnEULAAccepted(new EULAEventArgs { Signature = "..." });
      }
    }
    public class FormA : Form
    {
      public FormA()
      {
        // ...
        formB.EULAAccepted += EULAAccepted;
      }
      private void EULAAccepted(object sender, EULAEventArgs e)
      {
        this.label1.Text = String.Format("Thank you {0} for accepting the EULA.",
                                                  e.Signature);
      }
    }
