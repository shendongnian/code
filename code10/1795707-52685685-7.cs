    public partial class PhrasesFrame
    {
        private TH id;
        public PhrasesFrame()
        {
            Settings.SettingsChanged += this.SettingsChanged;
        }
        private void SetC1Btn()
        {
            var a = (int)this.id;
            //Other operations
        }
        private void SettingsChanged(object sender, Settings.SettingsEventArgs e)
        {
            this.id = e.THValue;
            SetC1Btn();
        }
    }
