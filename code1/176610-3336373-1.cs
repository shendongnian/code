      if ((d == DialogResult.OK) && (this.lb_Log.Items.Count != 0))
      {
          for (int i = 0; i < this.lb_Log.Items.Count; i++)
          {
              if ((s = this.sfd_Log.OpenFile()) != null)
              {
    
                using (StreamWriter outfile = new StreamWriter(s)
                {
                    outfile.Write(this.lb_Log.Items[i]);
                 }
    
                  
              } 
          }
          s.Close();
      }
