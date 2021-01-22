            Interlocked.Increment(ref threadRunning);
            ThreadPool.QueueUserWorkItem(o =>
            {
                // [snip]: Do some work involving compiling code already in memory with CSharpCodeProvider
                // provide some pretty feedback
                lock (iconLock)
                {
                    notifyIcon.Icon = (iconIsOut ? Properties.Resources.Icon16in : Properties.Resources.Icon16out);
                    iconIsOut = !iconIsOut;
                }
                Interlocked.Decrement(ref threadRunning);
            });
