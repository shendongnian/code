    public class CustomPalette : PaletteSet
    {
        private PaletteUserControl userControl;
        public PaletteUserControl PaletteUserControl => userControl;
        public CustomPalette() : base("CustomPalette")
        {
            Style = PaletteSetStyles.ShowAutoHideButton |
                    PaletteSetStyles.ShowCloseButton |
                    PaletteSetStyles.ShowPropertiesMenu;
            userControl = new PaletteUserControl();
            AddVisual("PaletteUserControl", userControl);
        }
    }
