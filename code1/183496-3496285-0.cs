     public void MetronomeStarter() 
            { 
                Listener listen = new Listener(); 
                listen.MetronomeItem = this;
                ListenerDelegate del = new ListenerDelegate(listen.Starter); 
                del.BeginInvoke(myCallback, del); 
            } 
