            foreach (Connection connect in connections)
            {
                if (searching == true)
                {
                    if (connect.SERVERID == ServerID)
                    {
                        connect.Stop();
                        isFound = true;
                        searching = false;
                        connections.Remove(connect);
                    }
                }
            }
