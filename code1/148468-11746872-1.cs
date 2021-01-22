      public class MyErrorProvider : ErrorProvider
      {
    
        public List<Control> GetControls()
        {
          return this.GetControls(this.ContainerControl);
        }
    
        public List<Control> GetControls(Control ParentControl)
        {
          List<Control> ret = new List<Control>();
    
          if (!string.IsNullOrEmpty(this.GetError(ParentControl)))
            ret.Add(ParentControl);
    
          foreach (Control c in ParentControl.Controls)
          {
            List<Control> child = GetControls(c);
            if (child.Count > 0)
              ret.AddRange(child);
          }
    
          return ret;
        }
      }
