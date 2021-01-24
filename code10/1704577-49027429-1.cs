    public dynamic EnablePage()
            {
               json = @"{""id"":12345,""method"":""Page.enable""}";
                Thread.Sleep(1000);
                return this.SendCommand(json);
            }
            public dynamic EnableRuntime()
            {
                json = @"{""id"":12345,""method"":""Runtime.enable""}";
                Thread.Sleep(1000);
                return this.SendCommand(json);
            }
            public dynamic EnableNetwork()
            {
                json = @"{""id"":12345,""method"":""Network.enable""}";
                Thread.Sleep(1000);
                return this.SendCommand(json);
            }
