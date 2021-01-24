	private void cmdMaxCompressPNG_Click(object sender, EventArgs e)
	{
		pbStatus.Maximum = lstFiles.Items.Count;
	
		var query =
			from FileName in Load_Listbox_Data().ToObservable()
			from u in Observable.Start(() => 
				System.Diagnostics.Process
					.Start("optipng.exe", String.Format("\"{0}\"", FileName))
					.WaitForExit())
			select u;
	
		query
			.ObserveOn(this) //marshall back to UI thread
			.Subscribe(
				x => pbStatus.Value += 1,
				() =>
				{
					lstFiles.Items.Clear();
					pbStatus.Value = 0;
					MessageBox.Show(text: "Task Complete", caption: "Status Update");
				});
	}
