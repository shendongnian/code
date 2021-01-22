    public void Dispose()
    {
            try
            {
                if (channel.State == CommunicationState.Faulted)
                {
                    channel.Abort();
                }
                else
                {
                    channel.Close();
                }
            }
            catch (CommunicationException)
            {
                channel.Abort();
            }
            catch (TimeoutException)
            {
                channel.Abort();
            }
            catch (Exception)
            {
                channel.Abort();
                throw;
            }
    }
