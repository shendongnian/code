	var cancellationToken = cancellationTokenSource.Token;
	await server.WaitForConnectionAsync(cancellationToken);
	
	if(!cancellationToken.IsCancellationRequested)
	{
		await server.WriteAsync(new byte[] { 1, 2, 3, 4 }, 0, 4, cancellationToken);
	}
		
	if(!cancellationToken.IsCancellationRequested)
	{
		var buffer = new byte[4];
		await server.ReadAsync(buffer, 0, 4, cancellationToken);
	}
		
	Console.WriteLine("exit server");
