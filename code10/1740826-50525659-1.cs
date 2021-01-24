	var f = new Form();
	var t = new TextBox();
	t.Dock = DockStyle.Fill;
	t.Multiline = true;
	f.Controls.Add(t);
	f.Load += (s, e) => {
		Process process = new Process();
        process.StartInfo.FileName = "python";
		process.StartInfo.Arguments = @"d:\script.py";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.OutputDataReceived += (s2, e2) => {
			t.Text += e2.Data + Environment.NewLine;
		};
        process.Start();
        process.BeginOutputReadLine();
	};
	f.ShowDialog();
