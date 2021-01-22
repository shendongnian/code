                JID jid = new JID(txtName.Text, ServerName,Resource);
                    jClient.User = txtName.Text;
                    jClient.Password = txtNewPwd.Text;
                    jClient.Connect();
                    jClient.Register(jid);
                    jClient.AutoLogin = false;
                    jClient.Close(true);
                   
                    jClient.OnLoginRequired += new bedrock.ObjectHandler(jc_OnLoginRequired);
                    jClient.OnRegisterInfo += new RegisterInfoHandler(this.jc_OnRegisterInfo);
                    jClient.OnRegistered += new IQHandler(jc_OnRegistered);
