         public void Send()
        {
            foreach (NotificationConnection conn in this.notificationConnections)
            {
               // Console.Write("Start Sending");
                conn.start(P12File, P12FilePassword);
            }
        }
