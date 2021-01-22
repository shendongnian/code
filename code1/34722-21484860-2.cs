            System.Threading.Timer timer = null;
            var cb = new System.Threading.TimerCallback((state) =>
            {
                timer.Dispose();
                if (!onUIThread)
                    action();
                else
                    CallOnUIThread(() =>
                        {
                            action();
                        }, async);
            });
            timer = new System.Threading.Timer(cb, null, delayInMilliseconds, System.Threading.Timeout.Infinite);
`
