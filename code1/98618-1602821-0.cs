    using System;
    using System.Timers;
    using StackOverflow.Answers.InjectTaskWithVaryingParameters.FakeDomain;
    namespace StackOverflow.Answers.InjectTaskWithVaryingParameters
    {
        public static class ExampleUsage
        {
            public static void Example1()
            {
                // using timed task runner with no parameters
                var timedProcess = new UsingParams.TimedProcess(300, FakeWork.NoParameters);
                var timedProcess2 = new UsingGenerics.TimedProcess(300, FakeWork.NoParameters);
            }
            public static void Example2()
            {
                // using timed task runner with a single typed parameter 
                var timedProcess =
                    new UsingParams.TimedProcess(300,
                        p => FakeWork.SingleParameter((string)p[0]),
                        "test"
                    );
                var timedProcess2 =
                    new UsingGenerics.TimedProcess<StringParameter>(
                            300,
                            p => FakeWork.SingleParameter(p.Name),
                            new StringParameter()
                            {
                                Name = "test"
                            }
                    );
            }
            public static void Example3()
            {
                // using timed task runner with a bunch of variously typed parameters 
                var timedProcess =
                    new UsingParams.TimedProcess(300,
                        p => FakeWork.LotsOfParameters(
                            (string)p[0],
                            (DateTime)p[1],
                            (int)p[2]),
                        "test",
                        DateTime.Now,
                        123
                    );
                var timedProcess2 =
                    new UsingGenerics.TimedProcess<LotsOfParameters>(
                        300,
                        p => FakeWork.LotsOfParameters(
                            p.Name,
                            p.Date,
                            p.Count),
                        new LotsOfParameters()
                        {
                            Name = "test",
                            Date = DateTime.Now,
                            Count = 123
                        }
                    );
            }
        }
        /* 
         * Some mock objects for example.
         * 
         */
        namespace FakeDomain
        {
            public static class FakeWork
            {
                public static void NoParameters()
                {
                }
                public static void SingleParameter(string name)
                {
                }
                public static void LotsOfParameters(string name, DateTime Date, int count)
                {
                }
            }
            public class StringParameter
            {
                public string Name { get; set; }
            }
            public class LotsOfParameters
            {
                public string Name { get; set; }
                public DateTime Date { get; set; }
                public int Count { get; set; }
            }
        }
        /*
         * Advantages: 
         *      - no additional types required         
         * Disadvantages
         *      - not strongly typed
         *      - requires explicit casting
         *      - requires "positional" array references 
         *      - no compile time checking for type safety/correct indexing position
         *      - harder to maintin if parameters change
         */
        namespace UsingParams
        {
            public delegate void NoParametersWrapperDelegate();
            public delegate void ParamsWrapperDelegate(params object[] parameters);
            public class TimedProcess : IDisposable
            {
                public TimedProcess()
                    : this(0)
                {
                }
                public TimedProcess(int interval)
                {
                    if (interval > 0)
                        InitTimer(interval);
                }
                public TimedProcess(int interval, NoParametersWrapperDelegate task)
                    : this(interval, p => task(), null) { }
                public TimedProcess(int interval, ParamsWrapperDelegate task, params object[] parameters)
                    : this(interval)
                {
                    _task = task;
                    _parameters = parameters;
                }
                private Timer timer;
                private ParamsWrapperDelegate _task;
                private object[] _parameters;
                public bool InProcess { get; protected set; }
                public bool Running
                {
                    get
                    {
                        return timer.Enabled;
                    }
                }
                private void InitTimer(int interval)
                {
                    if (timer == null)
                    {
                        timer = new Timer();
                        timer.Elapsed += TimerElapsed;
                    }
                    timer.Interval = interval;
                }
                public void InitExecuteProcess()
                {
                    timer.Stop();
                    InProcess = true;
                    RunTask();
                    InProcess = false;
                    timer.Start();
                }
                public void RunTask()
                {
                    TimedProcessRunner.RunTask(_task, _parameters);
                }
                public void TimerElapsed(object sender, ElapsedEventArgs e)
                {
                    InitExecuteProcess();
                }
                public void Start()
                {
                    if (timer != null && timer.Interval > 0)
                        timer.Start();
                }
                public void Start(int interval)
                {
                    InitTimer(interval);
                    Start();
                }
                public void Stop()
                {
                    timer.Stop();
                }
                private bool disposed = false;
                public void Dispose(bool disposing)
                {
                    if (disposed || !disposing)
                        return;
                    timer.Dispose();
                    disposed = true;
                }
                public void Dispose()
                {
                    Dispose(true);
                }
                ~TimedProcess()
                {
                    Dispose(false);
                }
            }
            public static class TimedProcessRunner
            {
                public static void RunTask(ParamsWrapperDelegate task)
                {
                    RunTask(task, null);
                }
                public static void RunTask(ParamsWrapperDelegate task, params object[] parameters)
                {
                    task.Invoke(parameters);
                }
            }
        }
        /*
         * Advantage of this method: 
         *      - everything is strongly typed         
         *      - compile time and "IDE time" verified
         * Disadvantages:
         *      - requires more custom types 
         */
        namespace UsingGenerics
        {
            public class TimedProcess : TimedProcess<object>
            {
                public TimedProcess()
                    : base() { }
                public TimedProcess(int interval)
                    : base(interval) { }
                public TimedProcess(int interval, NoParametersWrapperDelegate task)
                    : base(interval, task) { }
            }
            public class TimedProcess<TParam>
            {
                public TimedProcess()
                    : this(0)
                {
                }
                public TimedProcess(int interval)
                {
                    if (interval > 0)
                        InitTimer(interval);
                }
                public TimedProcess(int interval, NoParametersWrapperDelegate task)
                    : this(interval, p => task(), default(TParam)) { }
                public TimedProcess(int interval, WrapperDelegate<TParam> task, TParam parameters)
                    : this(interval)
                {
                    _task = task;
                    _parameters = parameters;
                }
                private Timer timer;
                private WrapperDelegate<TParam> _task;
                private TParam _parameters;
                public bool InProcess { get; protected set; }
                public bool Running
                {
                    get
                    {
                        return timer.Enabled;
                    }
                }
                private void InitTimer(int interval)
                {
                    if (timer == null)
                    {
                        timer = new Timer();
                        timer.Elapsed += TimerElapsed;
                    }
                    timer.Interval = interval;
                }
                public void InitExecuteProcess()
                {
                    timer.Stop();
                    InProcess = true;
                    RunTask();
                    InProcess = false;
                    timer.Start();
                }
                public void RunTask()
                {
                    TaskRunner.RunTask(_task, _parameters);
                }
                public void TimerElapsed(object sender, ElapsedEventArgs e)
                {
                    InitExecuteProcess();
                }
                public void Start()
                {
                    if (timer != null && timer.Interval > 0)
                        timer.Start();
                }
                public void Start(int interval)
                {
                    InitTimer(interval);
                    Start();
                }
                public void Stop()
                {
                    timer.Stop();
                }
                private bool disposed = false;
                public void Dispose(bool disposing)
                {
                    if (disposed || !disposing)
                        return;
                    timer.Dispose();
                    disposed = true;
                }
                public void Dispose()
                {
                    Dispose(true);
                }
                ~TimedProcess()
                {
                    Dispose(false);
                }
            }
            public delegate void NoParametersWrapperDelegate();
            public delegate void WrapperDelegate<TParam>(TParam parameters);
            public static class TaskRunner
            {
                public static void RunTask<TParam>(WrapperDelegate<TParam> task)
                {
                    RunTask(task, default(TParam));
                }
                public static void RunTask<TParam>(WrapperDelegate<TParam> task, TParam parameters)
                {
                    task.Invoke(parameters);
                }
            }
        }
    }
