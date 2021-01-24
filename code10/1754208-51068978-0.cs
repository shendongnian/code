	private async void cmdMaxCompressPNG_Click(object sender, EventArgs e) {
		pbStatus.Maximum = lstFiles.Items.Count;
		List<string> FileList = Load_Listbox_Data();
		await Task.Run(() => {
			foreach (string FileName in FileList) {
				ShellandWait("optipng.exe", String.Format("\"{0}\"", FileName));
				pbStatus.GetCurrentParent().Invoke(new MethodInvoker(delegate { pbStatus.Value += 1; }));
			}         
		});
		lstFiles.Items.Clear();
		pbStatus.Value = 0;
		MessageBox.Show(text: "Task Complete", caption: "Status Update");
	}
