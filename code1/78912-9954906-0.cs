	ServiceController mysqlServiceController = new ServiceController();
	mysqlServiceController.ServiceName = "MySql";
	var timeout = 3000;
	myServiceController.Start();
	
	try
	{
		//Wait till the service runs mysql   	
		ServiceController.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, new TimeSpan(0, timeout, 0));
	}
	catch (System.ServiceProcess.TimeoutException)
	{
		MessageBox.Show(string.Format("Starting the service \"{0}\" has reached to a timeout of ({1}) minutes, please check the service.", mysqlServiceController.ServiceName, timeout));
	}
