    public frmConexon()
		{
			InitializeComponent();
			this.txtEditor.ActiveTextAreaControl.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(TextArea_KeyUp);
		}
		void TextArea_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space && e.Control)
			{
				TextArea S = (TextArea)sender;
				MessageBox.Show(string.Format("CTRL + Spacio ({0})", S.Caret.ScreenPosition.ToString()));
			}
		}
