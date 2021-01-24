	private static IConnection _connection {get;set;}
	private static object LockObject = new object();
	private static IConnection GetConnection (string username, string password, string virtualHost, string hostName)
		get{
			// do work here in case the connection is closed as well.
			if (_connection == null){
				lock(LockObject){
					if (_connection == null){
						_connection = new ConnectionFactory
						   {
							   UserName = userName,
							   Password = password,
							   VirtualHost = virtualHost,
							   HostName = hostName
								   
						   }.CreateConnection();
					}
				}
				
			}
			return _connection;
		}
	}
	
	public ReturnCode AtomicPublish(string userName, string password, string virtualHost, string hostName, string exchangeName, string queueName, string message)
	{
			using (IModel model = GetConnection(userName, password, virtualHost, hostName).CreateModel()) //lazy loads the get connection
			{
				model.ExchangeDeclare(exchangeName, ExchangeType.Fanout, true);
				model.QueueDeclare(queueName, true, false, false, null);
				model.QueueBind(queueName, exchangeName, "", null);
				
				byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes(message);
				model.BasicPublish(exchangeName, string.Empty, null, messageBodyBytes);
			}
		
		return ReturnCode.OK;
	}
	
	
