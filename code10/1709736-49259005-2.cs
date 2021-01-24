	var send = Task.Run(async () =>
	{
		var buf = new byte[1000];
		while (!token.IsCancellationRequested)
		{
			r.NextBytes(buf);
			sent.AddRange(buf);
			await socket.WriteStream.WriteAsync(buf, 0, buf.Length, token);
			await socket.WriteStream.FlushAsync(token);
		}
	});
	var recv = Task.Run(async () =>
	{
		var buf = new byte[1000];
		while (!token.IsCancellationRequested)
		{
			var len = await socket.ReadStream.ReadAsync(buf, 0, buf.Length, token);
			recvd.AddRange(buf.Take(len));
		}
	});
