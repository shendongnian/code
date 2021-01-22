        void LingeringClose ()
		{
			int waited = 0;
			if (!Connected)
				return;
			try {
				Socket.Shutdown (SocketShutdown.Send);
				DateTime start = DateTime.UtcNow;
				while (waited < max_useconds_to_linger) {
					int nread = 0;
					try {
						if (!Socket.Poll (useconds_to_linger, SelectMode.SelectRead))
							break;
						if (buffer == null)
							buffer = new byte [512];
						nread = Socket.Receive (buffer, 0, buffer.Length, 0);
					} catch { }
					if (nread == 0)
						break;
					waited += (int) (DateTime.UtcNow - start).TotalMilliseconds * 1000;
				}
			} catch {
				// ignore - we don't care, we're closing anyway
			}
		}
