            PleaseWait.Create();
            try {
                System.Threading.Thread.Sleep(3000);
            }
            finally {
                PleaseWait.Destroy();
            }
