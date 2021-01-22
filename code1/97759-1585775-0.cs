    namespace CustomControls
    {
        public class LineThicknessComboBox : ComboBox
        {
            public LineThicknessComboBox()
            {
                // Design-mode capable code...
    
                if (DesignerProperties.GetIsInDesignMode(this)) return;
    
                // Design mode incapable code...
                DefaultStyleKeyProperty.OverrideMetadata(typeof(LineThicknessComboBox)
                            , new FrameworkPropertyMetadata(typeof(LineThicknessComboBox)));
    
            }
        }
    }
