    public interface IMyUserControl
    {
      void Save();
    }
    public class MemberDetails : UserConntrol, IMyUserControl
    {
      // Other stuff here.
      
      public void Save()
      {
        string forename = txtFname.Text;
        string surname = txtLname.Text;
        
        // Call your DAL here.
      }
    }
