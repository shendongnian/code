    using System;
    using System.ComponentModel;
    public static class CrossThreadHelper
    {
        public static bool CrossThread<T,R>(this ISynchronizeInvoke value, Action<T, R> action, T sender, R e)
        {
            if (value.InvokeRequired)
            {
                value.BeginInvoke(action, new object[] { sender, e });
            }
            return value.InvokeRequired;
        }
    }
