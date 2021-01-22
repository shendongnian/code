    public class WrapperClass
    {
        private WeakReference _Slave;
        public WrapperClass(SlaveClass slave)
        {
            _Slave = new WeakReference(slave);
        }
        public WrapperClass.ChangeHappened()
        {
            Object o = _Slave.Target;
            if (o != null)
                ((SlaveClass)o).ChangeHappened();
            else
                MasterClass.ChangeHappenedEvent -= ChangeHappened;
        }
    }
