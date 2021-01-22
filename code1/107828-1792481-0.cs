    foreach(Control C in ContainerID.Controls)
    {
        if ( C is TextBox )
        {
          if ( String.IsNullOrEmpty((C as TextBox).Text))
          {
              // Do things this way
          }        
        }    
    }
