    class SpecializedOpenFileDialog 
    {
        private OpenFileDialog ofd = new OpenFileDialog();
        public SpecializedOpenFileDialog()
        {
            ofd.Multiselect = false;
            ofd.Filter = "*.html";
        }
        public DialogResult ShowDialog()
        {
            return ofd.ShowDialog();
        }
        public string FileName
        {
            get 
            {
                return ofd.FileName;
            }
        }
    }
