cs
private int GetNextUnusedPort(int min, int max)
{
	if (max < min)
		throw new ArgumentException("Max cannot be less than min.");
	var ipProperties = IPGlobalProperties.GetIPGlobalProperties();
	var usedPorts =
		ipProperties.GetActiveTcpConnections()
			.Where(connection => connection.State != TcpState.Closed)
			.Select(connection => connection.LocalEndPoint)
			.Concat(ipProperties.GetActiveTcpListeners())
			.Concat(ipProperties.GetActiveUdpListeners())
			.Select(endpoint => endpoint.Port)
			.ToArray();
	var firstUnused =
		Enumerable.Range(min, max - min)
			.Where(port => !usedPorts.Contains(port))
			.Select(port => new int?(port))
			.FirstOrDefault();
	if (!firstUnused.HasValue)
		throw new Exception($"All local TCP ports between {min} and {max} are currently in use.");
	return firstUnused.Value;
}
