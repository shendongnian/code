    public static Control DeepFindControl(Control c, string id)
    {
       if (c.ID == id)
       { 
         return c;
       }
       if (c.HasControls)
       {
          Control temp;
          foreach (var subcontrol in c.Controls)
          {
              temp = DeepFindControl(subcontrol, id);
              if (temp != null)
              {
                  return temp; 
              }
          }
       }
       return null;
    }
