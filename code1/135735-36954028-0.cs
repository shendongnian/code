            if (ex.Errors.Count > 0) // Assume the interesting stuff is in the first error
            {
                switch (ex.Errors[0].Number)
                {
                    case 547: // Foreign Key violation
                        lblError.Text = "Cannot Delete this Record this is associated with other record...!";
                        
                        break;
                    default:
                      throw;
                }
            }
        }
