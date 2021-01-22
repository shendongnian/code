                private string _saveFile;
		[BrowsableAttribute(true)]
		[EditorAttribute(typeof(SaveFileNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
		public string SaveFileEditorVlad
		{
			get { return _saveFile; }
			set { _saveFile = value; }
		}
