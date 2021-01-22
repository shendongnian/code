<pre>
public void Start()
{
    lock (runLock)
    {
        if (_IsRunning == true)
            return;
        _IsRunning = true;
        (new System.Threading.Thread(new System.Threading.ThreadStart(SendLoop))).Start();
    }
}
public void Stop()
{
    lock (runLock)
    {
        _IsRunning = false;
    }
}
</pre>
