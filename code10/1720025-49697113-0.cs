    using System.Threading;
    class Test : MonoBehaviour {
        Ping result;
        private object pingLock;
        void Start() {
            pingLock = new object();
            new Thread(ThingRunningOffMainThread).Start();
            StartCoroutine(DoPing());
        }
        IEnumerator DoPing()
        {
            WaitForSeconds f = new WaitForSeconds(0.05f);
            Ping p = new Ping("ADDR");
    
            while (!p.isDone)
            {
                yield return f;
            }
            Monitor.Enter(pingLock);
            result = p;
            Monitor.Pulse(pingLock);
            Monitor.Exit(pingLock);
        }
    
    
        void ThingRunningOffMainThread() {
            if (result == null) {
                Monitor.Enter(pingLock);
                while (result == null) {
                    Monitor.Wait(pingLock);
                }
                Monitor.Exit(pingLock);
            }
            PingFinished(pingLock);
        }
    }
