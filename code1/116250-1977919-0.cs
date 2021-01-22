    private void Execute()
    {
    	Exception exception = null;
    
    	Thread thread2 = new Thread(() =>
    	{
    		while (true)
    		{
    			if (exception != null)
    			{
    				File.AppendAllText("Error.txt", "\r\n" + exception.Message + "\r\n" + exception.StackTrace + "\r\n" + exception.StackTrace);
    			}
    		}
    		
    	});
    
    
    	Thread thread1 = new Thread(() =>
    	{
    		try
    		{
    			new Action(() =>
    			{
    				new Action(() =>
    				{
    					new Action(() =>
    					{
    						new Action(() =>
    						{
    							new Action(() =>
    							{
    								new Action(() =>
    								{
    									new Action(() =>
    									{
    										new Action(() =>
    										{
    											new Action(() =>
    											{
    												new Action(() =>
    												{
    													new Action(() =>
    													{
    														new Action(() =>
    														{
    															new Action(() =>
    															{
    																new Action(() =>
    																{
    																	new Action(() =>
    																	{
    																		new Action(() =>
    																		{
    																			throw new Exception("E1");
    																		}).Invoke();
    																	}).Invoke();
    																}).Invoke();
    															}).Invoke();
    														}).Invoke();
    													}).Invoke();
    												}).Invoke();
    											}).Invoke();
    										}).Invoke();
    									}).Invoke();
    								}).Invoke();
    							}).Invoke();
    						}).Invoke();
    					}).Invoke();
    				}).Invoke();
    			}).Invoke();
    		}
    		catch (Exception ex)
    		{
    			exception = ex;
    		}
    	});
    	
    	Thread thread3 = new Thread(() =>
    	{
    		try
    		{
    			new Action(() =>
    			{
    				new Action(() =>
    				{
    					new Action(() =>
    					{
    						new Action(() =>
    						{
    							new Action(() =>
    							{
    								new Action(() =>
    								{
    									new Action(() =>
    									{
    										new Action(() =>
    										{
    											new Action(() =>
    											{
    												new Action(() =>
    												{
    													new Action(() =>
    													{
    														new Action(() =>
    														{
    															new Action(() =>
    															{
    																new Action(() =>
    																{
    																	new Action(() =>
    																	{
    																		new Action(() =>
    																		{
    																			throw new Exception("E2");
    																		}).Invoke();
    																	}).Invoke();
    																}).Invoke();
    															}).Invoke();
    														}).Invoke();
    													}).Invoke();
    												}).Invoke();
    											}).Invoke();
    										}).Invoke();
    									}).Invoke();
    								}).Invoke();
    							}).Invoke();
    						}).Invoke();
    					}).Invoke();
    				}).Invoke();
    			}).Invoke();
    		}
    		catch (Exception ex)
    		{
    			exception = ex;
    		}
    	});
    
    	thread2.Priority = ThreadPriority.BelowNormal;
    	thread2.Start();
    
    	thread1.Start();			
    	thread3.Start();
    
    	
    	
    	thread1.Join(20000);
    	thread2.Join(20000);
    }
