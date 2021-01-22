            var app = new PP.Application();
            PP.Presentation pres = null;
            try
            {
                Process.Start(inputFile);
                var presCol = app.Presentations;
                // Waiting for loading
                Thread.Sleep(2000);
                pres = presCol[inputFile];
                // Your code there
                // ...............
            }
            catch (System.Exception ex)
            {
                Log.Error(ex.Message);
                throw;
            }
            finally
            {
                if (pres != null)
                {
                    pres.Close();
                }
                if (app != null)
                {
                    app.Quit();
                }
                pres = null;
                app = null;
            }
