    case "3":
                                sendCommand("HSPD=500000");
                                Thread.Sleep(500);
                                sendCommand("LSPD=250000");
                                Thread.Sleep(500);
                                sendCommand("X0");
                                string x = Convert.ToString(Fn.backconvert(loopCommands("PX")));
    
                                while (x != lnArr[4])
                                {
                                    Thread.Sleep(250);
                                    s = Convert.ToString(Fn.backconvert(loopCommands("PX"))); // <-- this does not match the while so it was getting stuck in the loop 
                                }
                                Thread.Sleep(1000);
                                sendCommand("HSPD=250000");
                                sendCommand("LSPD=50000");
                                break;
