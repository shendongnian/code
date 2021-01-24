    private Task BlinkShort(Task previousTask = null)
    {
        var action = new Action(() =>
        {
            SetColorSafe(true);
            Task.Delay(400).Wait();
            SetColorSafe(false);
            Task.Delay(500).Wait();
        });
        var t = Task.Run(action);
        if (previousTask != null) // already threaded
        {
            t.Wait();
        }
        return t;
    }
    private Task BlinkLong(Task previousTask = null)
    {
        var action = new Action(() =>
        {
            SetColorSafe(true);
            Task.Delay(1200).Wait();
            SetColorSafe(false);
            Task.Delay(500).Wait();
        });
        var t = Task.Run(action);
        if (previousTask != null) // already threaded
        {
            t.Wait();
        }
        return t;
    }
    private void SetColorSafe(bool on)
    {
        if (InvokeRequired)
        {
            Invoke(new Action(() => {
                SetColorSafe(on);
            }));
            return;
        }
        if (on)
        {
            BackColor = Color.DodgerBlue;
        }
        else
        {
            BackColor = Color.Gray;
        }
    }
