    using System.Windows.Forms.VisualStyles;
    ...
    
        public Form1()
        {
          InitializeComponent();
          if (Application.RenderWithVisualStyles)
          {
            VisualStyleRenderer rndr = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
            Color c = rndr.GetColor(ColorProperty.TextColor);
            label1.ForeColor = c;
          }
        }
