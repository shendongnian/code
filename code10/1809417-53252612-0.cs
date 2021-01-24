    public static int ConnectToServer()
        {
            int result = 0;
            var _netresource = new NetResource()
            {
                scope = _ResourceScope.GlobalNetwork,
                ResourceType = _ResourceType.Any,
                DisplayType = _ResourceDisplayType.Server,
                RemoteName = $@"\\{Program._globaldata.Server}"
            };
            string _username = $@"{Program._globaldata.Server}\RemoteDKBuild";
            string _passsword = "Hic3nuasno6epyndtenars4yDifrts";
            var _connectiontype = (int)_ConnectionType.Interactive | (int)_ConnectionType.Temporary;
            LogWriter.WriteLogFile((int)LogWriter.EventID.NetMan, (int)LogWriter.EventType.Info,
                                    $@"Attempting to connect to: \\{_netresource.RemoteName}");
            result = WNetAddConnection2(_netresource, _passsword, _username, _connectiontype);
            var res = Marshal.GetLastWin32Error();
            if (result !=0)
            {
                LogWriter.WriteLogFile((int)LogWriter.EventID.NetMan, (int)LogWriter.EventType.Error,
                                        $@"Failed to connect to: \\{_netresource.RemoteName}, Return Result: {result.ToString()}, Win32 Error Code: {res.ToString()}");
                result = res;
            }
            else
            {
                LogWriter.WriteLogFile((int)LogWriter.EventID.NetMan, (int)LogWriter.EventType.Info,
                                        $@"Connection to: \\{_netresource.RemoteName} has been successfull.");
            }
            return result;
        }
    [DllImport("mpr.dll", SetLastError = true)]
    private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);
