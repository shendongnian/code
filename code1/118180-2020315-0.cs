      public Form1()
      {
         InitializeComponent();
         List<IntPtr> handles = GetHandles(this.Controls);
      }
      public List<IntPtr> GetHandles(Control.ControlCollection inControls)
      {
         List<IntPtr> list_of_handles = new List<IntPtr>();
         if (inControls.Count > 0)
         {
            foreach (Control c in inControls)
            {
               list_of_handles.Add(c.Handle);
               list_of_handles.AddRange(GetHandles(c.Controls));
            }
         }
         return list_of_handles;
      }
