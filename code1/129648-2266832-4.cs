        private void uploadButton_Click(object sender, EventArgs e)
        {
            object[] params = new object[] { "your file what ever type this is a generic example"};
            Thread uploadThread = new Thread(new ParameterizedThreadStart(processUpload));
            uploadThread.IsBackground = true;
            uploadThread.Start(params);
        }
        
        private void processUpload(object params){
           // do upload logic here 
           object[] _params = (object[])params;
           string s = _params[0].ToString();
        }
