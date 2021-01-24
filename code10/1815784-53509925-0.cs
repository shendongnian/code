			using (var sshClient = new SshClient(host, 22, username, password)) {
				sshClient.Connect();
				var cmd = sshClient.CreateCommand("for i in `seq 1 10`; do sleep 1; echo $i; done");
				var asyncResult = cmd.BeginExecute();
				var outputReader = new StreamReader(cmd.OutputStream);
				string output;
				while (!asyncResult.IsCompleted) {
					output = outputReader.ReadToEnd();
					Console.Out.Write(output);
				}
				output = outputReader.ReadToEnd();
				Console.Out.Write(output);
			}
