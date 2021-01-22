    public class CustomToolTip : ToolTip
    {
        public CustomToolTip () : base()
        {
            this.Popup += new PopupEventHandler(this.OnPopup);
        }
        private void OnPopup(object sender, PopupEventArgs e) 
        {
            // Set custom size of the tooltip
            e.ToolTipSize = new Size(200, 100);
        }
    }
