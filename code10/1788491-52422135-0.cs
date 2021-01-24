    muntrainout.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler((sender, e) =>
				{
					//Console.WriteLine(e.Data);
					Frame1.Dispatcher.Invoke(() => { Frame1.Content += e.Data+Environment.NewLine; });
				}
