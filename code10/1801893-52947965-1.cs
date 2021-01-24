        public static void WaitForAjaxRequest(this IWebDriver webDriver)
        {
            WaitHelper.WaitFor(
                Config.ShortTime,
                TimeSpan.FromMilliseconds(100),
                () =>
                {
                    return !webDriver.IsAjaxRequestInProgress();
                });
        }
        public static bool IsAjaxRequestInProgress(this IWebDriver webDriver)
        {
            return webDriver.ExecuteJs<bool>("return window.jQuery ? window.jQuery.active != 0 : false");
        }
