    public partial class EmployeeDomainContext : DomainContext
    {
        partial void OnCreated()
        {
            PropertyInfo channelFactoryProperty = this.DomainClient.GetType().GetProperty("ChannelFactory");
            if (channelFactoryProperty == null)
            {
                throw new InvalidOperationException(
                  "There is no 'ChannelFactory' property on the DomainClient.");
            }
            ChannelFactory factory = (ChannelFactory)channelFactoryProperty.GetValue(this.DomainClient, null);
            factory.Endpoint.Binding.SendTimeout = new TimeSpan(0, 10, 0); 
        }
    }
