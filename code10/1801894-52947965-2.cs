        public static void WaitForDocumentReady(this IWebDriver webDriver)
        {
            WaitHelper.WaitFor(
                TimeSpan.FromSeconds(6),
                TimeSpan.FromMilliseconds(200),
                () =>
                {
                    try
                    {
                        string readyState = webDriver.ExecuteJs<string>("if (document.readyState) return document.readyState;");
                        var ajaxInProgress = webDriver.IsAjaxRequestInProgress();
                        return readyState.ToLower() == "complete" && !ajaxInProgress;
                    }
                    catch (InvalidOperationException e)
                    {
                        // Window is no longer available
                        return e.Message.ToLower().Contains("unable to get browser");
                    }
                    catch (WebDriverException e)
                    {
                        // Browser is no longer available
                        return e.Message.ToLower().Contains("unable to connect");
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                });
        }
