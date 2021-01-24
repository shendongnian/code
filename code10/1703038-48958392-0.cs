	} catch (Exception ex) {
		var inner = ex.InnerException as System.Net.Sockets.SocketException;
		System.Console.WriteLine(inner.ErrorCode);
		System.Console.WriteLine(inner.Message);
	}
