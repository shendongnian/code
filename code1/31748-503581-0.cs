		private void OnceADayRunnerTimer_Elapsed(object sender, ElapsedEventArgs e)
		{
			using (NDC.Push(GetType().Name))
			{
				try
				{
					log.DebugFormat("Checking if it's time to process at: {0}", e.SignalTime);
					log.DebugFormat("IsTestMode: {0}", IsTestMode);
					if ((e.SignalTime.Minute == MinuteToCheck && e.SignalTime.Hour == HourToCheck) || IsTestMode)
					{
						log.InfoFormat("Processing at: Hour = {0} - Minute = {1}", e.SignalTime.Hour, e.SignalTime.Minute);
						OnceADayTimer.Enabled = false;
						OnceADayMethod();
						OnceADayTimer.Enabled = true;
						IsTestMode = false;
					}
					else
					{
						log.DebugFormat("Not correct time at: Hour = {0} - Minute = {1}", e.SignalTime.Hour, e.SignalTime.Minute);
					}
				}
				catch (Exception ex)
				{
					OnceADayTimer.Enabled = true;
					log.Error(ex.ToString());
				}
				OnceADayTimer.Start();
			}
		}
