    #if USE_DELEGATES
    public class MsBitsEnum<T> : IEnumerable<T>
    {
        Action _reset;
        Func<T> _next;
        Func<int> _count;
        public MsBitsEnum(Action reset, Func<T> next, Func<int> count)
        {
            _reset = reset;
            _next = next;
            _count = count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            _reset();
            int count = _count();
            for (int i = 0; i < count; ++i)
                yield return _next();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class MsBitsJobs : MsBitsEnum<IBackgroundCopyJob>
    {
        public MsBitsJobs(IEnumBackgroundCopyJobs jobs)
            : base(() => jobs.Reset(),
                   () => 
                   {
                       IBackgroundCopyJob job = null;
                       uint fetched = 0;
                       jobs.Next(1, out job, out fetched);
                       return fetched == 1 ? job : null;
                   },
                   () => 
                   {
                       uint count;
                       jobs.GetCount(out count);
                       return (int) count;
                   })
        {
        }
    }
    public class MsBitsFiles : MsBitsEnum<IBackgroundCopyFile>
    {
        public MsBitsFiles(IEnumBackgroundCopyFiles files)
            : base(() => files.Reset(),
                   () =>
                   {
                       IBackgroundCopyFile file = null;
                       uint fetched = 0;
                       files.Next(1, out file, out fetched);
                       return fetched == 1 ? file : null;
                   },
                   () =>
                   {
                       uint count;
                       files.GetCount(out count);
                       return (int)count;
                   })
        {
        }
    }
    #else   // !USE_DELEGATES
    public abstract class MsBitsEnum<T> : IEnumerable<T>
    {
        protected abstract void Reset();
        protected abstract bool Next(out T item);
        public IEnumerator<T> GetEnumerator()
        {
            T item;
            Reset();
            while (Next(out item))
                yield return item;
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class MsBitsJobs : MsBitsEnum<IBackgroundCopyJob>
    {
        IEnumBackgroundCopyJobs _jobs;
        protected override void Reset()
        {
            _jobs.Reset();
        }
        protected override bool Next(out IBackgroundCopyJob job)
        {
            uint fetched;
            _jobs.Next(1, out job, out fetched);
            return fetched == 1;
        }
        public MsBitsJobs(IEnumBackgroundCopyJobs jobs)
        {
            _jobs = jobs;
        }
    }
    public class MsBitsFiles : MsBitsEnum<IBackgroundCopyFile>
    {
        IEnumBackgroundCopyFiles _files;
        protected override void Reset()
        {
            _files.Reset();
        }
        protected override bool Next(out IBackgroundCopyFile file)
        {
            uint fetched;
            _files.Next(1, out file, out fetched);
            return fetched == 1;
        }
        public MsBitsFiles(IEnumBackgroundCopyFiles files)
        {
            _files = files;
        }
    }
    #endif  //  !USE_DELEGATES
 
