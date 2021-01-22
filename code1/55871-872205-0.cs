      private static string _AppRegyPath = "Software\\Vendor Name\\Application Name";
      public Microsoft.Win32.RegistryKey AppCuKey
      {
          get
          {
              if (_appCuKey == null)
              {
                  _appCuKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(_AppRegyPath, true);
                  if (_appCuKey == null)
                      _appCuKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(_AppRegyPath);
              }
              return _appCuKey;
          }
          set { _appCuKey = null; }
      }
      private void RetrieveAndApplyState()
      { 
          string s = (string)AppCuKey.GetValue("textbox1Value");
          if (s != null) this.textbox1.Text = s;
          s = (string)AppCuKey.GetValue("Geometry");
          if (!String.IsNullOrEmpty(s))
          {
              int[] p = Array.ConvertAll<string, int>(s.Split(','),
                               new Converter<string, int>((t) => { return Int32.Parse(t); }));
              if (p != null && p.Length == 4)
              {
                  this.Bounds = ConstrainToScreen(new System.Drawing.Rectangle(p[0], p[1], p[2], p[3]));
              }
          }
      }
      private void SaveStateToRegistry()
      {
          AppCuKey.SetValue("textbox1Value", this.textbox1.Text);
          int w = this.Bounds.Width;
          int h = this.Bounds.Height;
          int left = this.Location.X;
          int top = this.Location.Y;
          AppCuKey.SetValue("Geometry", String.Format("{0},{1},{2},{3}", left, top, w, h);
      }
      private System.Drawing.Rectangle ConstrainToScreen(System.Drawing.Rectangle bounds)
      {
          Screen screen = Screen.FromRectangle(bounds);
          System.Drawing.Rectangle workingArea = screen.WorkingArea;
          int width = Math.Min(bounds.Width, workingArea.Width);
          int height = Math.Min(bounds.Height, workingArea.Height);
          // mmm....minimax            
          int left = Math.Min(workingArea.Right - width, Math.Max(bounds.Left, workingArea.Left));
          int top = Math.Min(workingArea.Bottom - height, Math.Max(bounds.Top, workingArea.Top));
          return new System.Drawing.Rectangle(left, top, width, height);
      }
