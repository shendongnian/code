    using namespace System::Net::Sockets;
    using namespace System::Net::NetworkInformation;
    TcpState GetTcpConnectionState(TcpClient ^ tcpClient)
    {
        TcpState tcpState = TcpState::Unknown;
        if (tcpClient != nullptr)
        {
            // Get all active TCP connections
            IPGlobalProperties ^ ipProperties = IPGlobalProperties::GetIPGlobalProperties();
            array<TcpConnectionInformation^> ^ tcpConnections = ipProperties->GetActiveTcpConnections();
            if ((tcpConnections != nullptr) && (tcpConnections->Length > 0))
            {
                // Get the end points of the TCP connection in question
                EndPoint ^ localEndPoint = tcpClient->Client->LocalEndPoint;
                EndPoint ^ remoteEndPoint = tcpClient->Client->RemoteEndPoint;
                // Run through all active TCP connections to locate TCP connection in question
                for (int i = 0; i < tcpConnections->Length; i++)
                {
                    if ((tcpConnections[i]->LocalEndPoint->Equals(localEndPoint)) && (tcpConnections[i]->RemoteEndPoint->Equals(remoteEndPoint)))
                    {
                        // Found active TCP connection in question
                        tcpState = tcpConnections[i]->State;
                        break;
                    }
                }
            }
        }
        return tcpState;
    }
    bool TcpConnected(TcpClient ^ tcpClient)
    {
        bool bTcpConnected = false;
        if (tcpClient != nullptr)
        {
            if (GetTcpConnectionState(tcpClient) == TcpState::Established)
            {
                bTcpConnected = true;
            }
        }
        return bTcpConnected;
    }
