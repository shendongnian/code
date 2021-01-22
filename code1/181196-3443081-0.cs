            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DialogResult LclResult;
            EESDatabasePersistentData LclPersist;
            LclPersist = new EESDatabasePersistentData();
            string LclDataType;
            string LclDatabase;
            string LclServer;
            string Password;
            string UserID;
            if (!LclPersist.GetConnection(out LclServer, out LclDatabase, out LclDataType, out UserID, out Password))
            {
                // Run the connection wizard
                GetConnection(out LclServer, out LclDatabase, out LclDataType, out UserID, out Password);
            }
            
            if (LclDataType == "ACCESS")
                InitDataAccess(LclDatabase);
            else if (LclDataType == "SQLSERVER")
                InitDataSQL(LclServer, LclDatabase, UserID, Password);
            if (OpenGood)
            {
                if (!System.Diagnostics.Debugger.IsAttached)
                {
                    FormSplash.Instance.SetupVersion();
                    ///////////////////////////////////
                    // If we don't call do events 
                    // splash delays loading.
                    Application.DoEvents();
                    FormSplash.Instance.Show();
                }
                Application.DoEvents();
                Application.Run(new FormMentorMain());
            }
            else
                Application.Exit();
