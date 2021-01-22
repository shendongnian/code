ISession session = null;
try
{
    // Creates a new session, or reconnects a disconnected session
    session = AcquireCurrentSession();
    // Database operations go here
}
catch
{
    session.Close();
    throw;
}
finally
{
    session.Disconnect();
}
