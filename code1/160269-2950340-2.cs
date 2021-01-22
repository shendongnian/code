    class ImageProcessing
    {
        private frmMain _form = null;    
        public ImageProcessing(frmMain form)
        {
            _form = form;
        }
        private UpdateStatusLabel(string text)
        {
            _form.StatusUpdate(text);
        }
    }
