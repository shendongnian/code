    // Main Form Class : Call Form Manager Class to Load Forms
            private void Load_Modules()
            {
                if (FrmMgr == null) { FrmMgr = new FormManager(this); }
            }
    
    
    // Form Manager Class : Load Forms
    
    // Constructor
            public FormManager(Form _MainParent)
            {
                Init_FrmMenu(_MainParent);
    
                // Frm1 is used here just as Example 
                Init_Frm1(_MainParent);
            }
    
    
            private void Init_FrmMenu(Form _MainParent)
            {
                if (frmMenu == null) { frmMenu = new f_Menu(); }
                frmMenu.MdiParent = _MainParent;
    
                var fSizeW = frmMenu.Size.Width;
                var fSizeH = frmMenu.Size.Height;
    
                var fLocX = frmMenu.Location.X;
                var fLocY = frmMenu.Location.Y;
    
                // Set Default Form Size
                using (fMenu_Data.fSize fMenu_Size = new fMenu_Data.fSize())
                {
                    fSizeW = fMenu_Size.DefaultSizeW;
                    fSizeH = fMenu_Size.DefaultSizeH;
    
                    // Requires "MinimumSize" instead of "Size" to Prevent Minimum Size Bug.
                    // Where it Prevents Setting the Form Size Bellow a Certain Value
                    frmMenu.MinimumSize = new System.Drawing.Size(fSizeW, fSizeH);
                }
    
                // Set Default Form Location
                using (fMenu_Data.fLocation fMenu_Location = new fMenu_Data.fLocation())
                {
                    fLocX = fMenu_Location.fLocX;
                    fLocY = fMenu_Location.fLocY;
    
                    frmMenu.Location = new System.Drawing.Point(fLocX, fLocY);
                }
    
                frmMenu.Show();
            }
