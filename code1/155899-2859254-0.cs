	private void MyForm_DragEnter(object sender, DragEventArgs e) {
		e.Effect = (e.Data.GetFormats().Any(f => f == DataFormats.FileDrop)
			? DragDropEffects.Copy
			: DragDropEffects.None);
	}
