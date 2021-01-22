    Packet packet =
        PacketBuilder.Build(DateTime.Now,
                            new EthernetLayer
                                {
                                    Source = new MacAddress("11:22:33:44:55:66"),
                                    Destination = new MacAddress("11:22:33:44:55:67"),
                                },
                            new IpV4Layer
                                {
                                    Source = new IpV4Address("1.2.3.4"),
                                    Destination = new IpV4Address("1.2.3.5"),
                                    Ttl = 64,
                                    Identification = 100,
                                },
                            new PayloadLayer
                                {
                                    Data = new Datagram(new byte[] {1, 2, 3, 4})
                                });
