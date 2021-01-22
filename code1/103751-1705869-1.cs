            foreach (Connection connect in connections)
            {
                if (connect.SERVERID == ServerID)
                {
                    connect.Stop();
                    isFound = true;
                    connections.Remove(connect);
                    break;
                }
            }
