    class MyMailMessage : MailMessage, IDisposable
    {
        private List<string> _tempFiles = new List<string>();
        
        public void Attach(string filename)
        {
            base.Attachments.Add(new Attachment(filename));
    		this._tempFiles.add(filename);
        }
    	
    	new public void Dispose()
    	{
    		base.Dispose();
    		this._tempFiles.Foreach(x => File.Delete(x));
    	}
    }
