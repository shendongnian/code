            public static void WaitForElementToExistInDom(Func<IWebElement> action)
            {
                RetryPolicy.Do(() =>
                {
                    if (!DoesElementExistInDom(action))
                        throw new RetryPolicyException();
                }, TimeSpan.FromMilliseconds(Timeouts.DefaultTimeSpanInMilliseconds), TestConstants.DefaultRetryCount);
            }
    
            public static bool DoesElementExistInDom(Func<IWebElement> action)
            {
                var doesExist = false;
                try
                {
                    var element = action.Invoke();
                    if (element != null)
                        doesExist = true;
                }
                catch (StaleElementReferenceException)
                {
                }
                catch (NullReferenceException)
                {
                }
                catch (NoSuchElementException)
                {
                }
    
                return doesExist;
            }
