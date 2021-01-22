       int tcpPort = 82131;
        // ------------------------------------------------------------
        BinaryServerFormatterSinkProvider serverProv =
            new BinaryServerFormatterSinkProvider();
        serverProv.TypeFilterLevel = TypeFilterLevel.Full; 
        RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
        serverProv.TypeFilterLevel = TypeFilterLevel.Full;
        IDictionary propBag = new Hashtable();
        // -----------------------------------------
        bool isSecure = [true/false];
        propBag["port"] = tcpPort ;
        propBag["typeFilterLevel"] = TypeFilterLevel.Full;
        propBag["name"] = "UniqueChannelName";  // here enter unique channel name
        if (isSecure)  // if you want remoting comm to be secure and encrypted
        {
            propBag["secure"] = isSecure;
            propBag["impersonate"] = false;  // change to true to do impersonation
        }
        // -----------------------------------------
        tcpChan = new TcpChannel(
            propBag, null, serverProv);
        ChannelServices.RegisterChannel(tcpChan, isSecure);
        // --------------------------------------------
        string uRI = MyUniversalResourceIndicatorName;
        // ---------------------------------------------
        RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(ImportServiceManager), uRI ,
            WellKnownObjectMode.SingleCall);
