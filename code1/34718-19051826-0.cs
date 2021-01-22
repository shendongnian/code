    using System.Windows.Forms;
    using System.Collections.Generic;
    using System;
    namespace EVEPlanetaryPlanner
    {
        public class DelayedDelegate
        {
           static private DelayedDelegate _instance = null;
            private Timer _runDelegates = null;
            private Dictionary<MethodInvoker, DateTime> _delayedDelegates = new Dictionary<MethodInvoker, DateTime>();
            public DelayedDelegate()
            {
            }
            static private DelayedDelegate Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new DelayedDelegate();
                    }
                    return _instance;
                }
            }
            public static void Add(MethodInvoker pMethod, int pDelay)
            {
                Instance.AddNewDelegate(pMethod, pDelay * 1000);
            }
            public static void AddMilliseconds(MethodInvoker pMethod, int pDelay)
            {
                Instance.AddNewDelegate(pMethod, pDelay);
            }
            private void AddNewDelegate(MethodInvoker pMethod, int pDelay)
            {
                if (_runDelegates == null)
                {
                    _runDelegates = new Timer();
                    _runDelegates.Tick += RunDelegates;
                }
                else
                {
                    _runDelegates.Stop();
                }
                _delayedDelegates.Add(pMethod, DateTime.Now + TimeSpan.FromMilliseconds(pDelay));
                StartTimer();
            }
            private void StartTimer()
            {
                if (_delayedDelegates.Count > 0)
                {
                    int delay = FindSoonestDelay();
                    if (delay == 0)
                    {
                        RunDelegates();
                    }
                    else
                    {
                        _runDelegates.Interval = delay;
                        _runDelegates.Start();
                    }
                }
            }
            private int FindSoonestDelay()
            {
                int soonest = int.MaxValue;
                TimeSpan remaining;
                foreach (MethodInvoker invoker in _delayedDelegates.Keys)
                {
                    remaining = _delayedDelegates[invoker] - DateTime.Now;
                    soonest = Math.Max(0, Math.Min(soonest, (int)remaining.TotalMilliseconds));
                }
                return soonest;
            }
            private void RunDelegates(object pSender = null, EventArgs pE = null)
            {
                try
                {
                    _runDelegates.Stop();
                    List<MethodInvoker> removeDelegates = new List<MethodInvoker>();
                    foreach (MethodInvoker method in _delayedDelegates.Keys)
                    {
                        if (DateTime.Now >= _delayedDelegates[method])
                        {
                            method();
                            removeDelegates.Add(method);
                        }
                    }
                    foreach (MethodInvoker method in removeDelegates)
                    {
                        _delayedDelegates.Remove(method);
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    StartTimer();
                }
            }
        }
    }
