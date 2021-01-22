    // Set form's state to 'executing', 
    // eg. Button.Enabled = false; label.Text = 'Executing';
    command.BeginExecuteNonQuery((asyncstate)=>
    {
       try
       {
          command.EndExecuteNotQuery();
       }
       catch(SqlException ex)
       {
         ...
       } 
       // Reset the form's state to 'Ready'
       Invoke (()=>
       {
         // eg. Button.Enabled = true; label.Text = 'Ready';
       }
    }
