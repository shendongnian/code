    public interface ICommand
      {
        void Execute ();
      }
    
      public class UpdateCommand : ICommand
      {
        public UpdateCommand ()
        {
          // Maybe some business logic has to be passed in the ctor.
        }
    
        public void Execute ()
        {
          // Do the update stuff here
        }
      }
    
      // somewhere in the Form:
    
      public void Button_Update_Click(object sender, EventArgs e)
      {
        UpdateCommand command = new UpdateCommand();
        command.Execute()
      }
