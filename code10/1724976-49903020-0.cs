    int step = 0;
    try
    {
        step = 1;
        var parsed = IPAddress.Parse(host);
        step = 2;
        var endpoint = new IPEndPoint(parsed, port);
        step = 3;
    	_socket.Connect(endpoint);
        step = 4;
    	CoreUtilities.LogToConsole("Successfully established a connection to the server.");
    }
    catch (Exception error)
    {
    	MessageBox.Show(error.Message, "Step " + step.ToString());
    }
