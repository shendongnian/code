      browser.FinishLoadingFrameEvent += (s, e) =>
            {
                if (e.IsMainFrame)
                {
                    foreach (var item in edificios)
                    {
                        browser.ExecuteJavaScript("criarMarker('" + item.id + "'," + item.lat + "," + item.lon + ");");
                    }
                    //browser.ExecuteJavaScript("jsCall");
                }
            };
