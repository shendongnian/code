		class Event
		{
			public void SendEmail()
			{
				var url = string.Format("http://myurl.com/r/Event?eventId={0}", EventId);
                //send emails...
			}
		}
