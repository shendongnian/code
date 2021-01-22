    using (var client = new MyBeanClient())
    {
        client.ChannelFactory.Credentials.Windows.ClientCredential = 
            new NetworkCredential("username", "password", "DOMAIN");
        client.addConsumer("whatever", "", "", "");
    }
