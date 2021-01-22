        void FileMessageEvent(object sender, MessageEventArgs e)
        {
        
            if (this.InvokeRequired == true)
            {
                this.BeginInvoke((MethodInvoker)delegate { 
                         lblMessage.Text=e.Message; 
                         Application.DoEvents(); 
                     }
                ); 
            
            }
        }
