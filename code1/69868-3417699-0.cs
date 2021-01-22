            for (int j = 0; j < 100; j++)
            {
                using (var client = new ServiceClient())
                {
                    client.Method();
                }
             }
