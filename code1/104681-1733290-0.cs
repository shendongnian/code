      public partial class Form1 : Form {
        private ToolStripMenuItem[] languages;
        private bool mBusy;
    
        public Form1() {
          InitializeComponent();
          languages = new ToolStripMenuItem[] { javaToolStripMenuItem, cSharpToolStripMenuItem, pythonToolStripMenuItem };
          foreach (var language in languages) {
            language.CheckOnClick = true;
            language.CheckedChanged += LanguageMenuItem_CheckedChanged;
          }
          menuStrip1.Renderer = new MyRenderer(languages);
        }
    
        void LanguageMenuItem_CheckedChanged(object sender, EventArgs e) {
          if (mBusy) return;
          mBusy = true;
          ToolStripMenuItem item = sender as ToolStripMenuItem;
          foreach (var language in languages) language.Checked = language == item;
          mBusy = false;
        }
    
        private class MyRenderer : ToolStripProfessionalRenderer {
          private ToolStripMenuItem[] languages;
          public MyRenderer(ToolStripMenuItem[] languages) { this.languages = languages; }
    
          protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e) {
            ToolStripMenuItem item = e.Item as ToolStripMenuItem;
            if (item != null && languages.Contains(item))
              RadioButtonRenderer.DrawRadioButton(e.Graphics, e.ImageRectangle.Location,
                System.Windows.Forms.VisualStyles.RadioButtonState.CheckedNormal);
            else
              base.OnRenderItemCheck(e);
          }
        }
      }
