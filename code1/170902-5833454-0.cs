    public static class Connection<T>
       {
          public static ChannelHolder Instance
          {
             get
             {
                return new ChannelHolder();
             }
          }
    
          public class ChannelHolder : IDisposable
          {
             public T Channel { get; set; }
    
             public ChannelHolder()
             {
                this.Channel = GetChannel();
             }
    
             public void Dispose()
             {
                IChannel connection = null;
                try
                {
                   connection = (IChannel)Channel;
                   connection.Close();
                }
                catch (Exception)
                {
                   if (connection != null)
                   {
                      connection.Abort();
                   }
                }
             }
          }
    }
