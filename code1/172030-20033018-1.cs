        private async void Application_Exit(object sender, EventArgs e)
        {
            // Tell DBSERVER_V14 pipe we have gone away
            var status = await SmartNibby_V13.connect_disconnect_async(MainPage.username, MainPage.website, false);
            if (status)
            {
                Console.WriteLine(status);
            }
        }
