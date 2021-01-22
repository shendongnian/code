    		Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();
			string document = null;
			using (OpenFileDialog dia = new OpenFileDialog())
			{
				dia.Filter = "MS Word (*.docx)|*.docx";
				if (dia.ShowDialog() == DialogResult.OK)
				{
					document = dia.FileName;
				}
			}			
			if (document != null)
			{
				Document doc = word.Documents.Open(document, ReadOnly: false, Visible: true);
				doc.Activate();
				string text = doc.Content.Text;
				int start = text.IndexOf('E') + 1;
				int end = text.IndexOf('F');
				if (start >= 0 && end >= 0 && end > start)
				{
					Range range = doc.Range(Start: start, End: end);
					range.Select();
				}
			}
