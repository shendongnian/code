        private CALayer borderLayer;
        int sublayerNumber = 0;
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                borderLayer = new CALayer();
                Control.Layer.AddSublayer(borderLayer);
                sublayerNumber = Control.Layer.Sublayers.Length - 1;
