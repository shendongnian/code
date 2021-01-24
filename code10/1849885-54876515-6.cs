    public partial class BaseApplication: Application, Application.IActivityLifecycleCallbacks
    {
        public int NumberActivitiesActive { get; protected set; }
    
        public static ApplicationState ApplicationState { get; protected set; } = ApplicationState.NotRunning;
    
        public static DateTime AppEnteredTime { get; protected set; } = DateTime.MinValue;
        public static DateTime AppLeftTime { get; protected set; } = DateTime.MinValue;
    
        public static double TimeInAppMs
        {
            get
            {
                if (AppLeftTime == DateTime.MinValue)
                    return DateTime.Now.Subtract(AppEnteredTime).TotalMilliseconds;
                else
                    return AppLeftTime.Subtract(AppEnteredTime).TotalMilliseconds;
            }
        }
    
    
        public static Activity CurrentActivity { get; private set; }
    
    
        // Used to store activities to be excluded from counts, such as Activities used to handle notifications in response to push notifications
        public static List<string> ExcludedActivities { get; } = new List<string>();
    
        public static void RegisterExcludedActivity(string activityName)
        {
            if (!ExcludedActivities.Contains(activityName))
                ExcludedActivities.Add(activityName);
        }
        public static void UnregisterExcludedActivity(string activityName)
        {
            ExcludedActivities.Remove(activityName);
        }
    
    
        public BaseApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer) { }
    
    
        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
            ApplicationState = ApplicationState.NotRunning;
        }
    
        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
            ApplicationState = ApplicationState.NotRunning;
        }
    
    
        public virtual void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CurrentActivity = activity;
        }
    
        public virtual void OnActivityDestroyed(Activity activity) // Exclude this activity because it only relates to a notification created in response to a  push notification
        {
            if (!ExcludedActivities.Contains(activity.LocalClassName) && NumberActivitiesActive <= 0)
                ApplicationState = ApplicationState.NotRunning;
        }
    
        public virtual void OnActivityPaused(Activity activity)
        {
        }
    
        public virtual void OnActivityResumed(Activity activity)
        {
            CurrentActivity = activity;
        }
    
        public virtual void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {
        }
    
        public virtual void OnActivityStarted(Activity activity)
        {
            CurrentActivity = activity;
            if (!ExcludedActivities.Contains(activity.LocalClassName))
            {
                if (NumberActivitiesActive == 0)
                {
                    AppEnteredTime = DateTime.Now;
                    ApplicationState = ApplicationState.Foreground;
                }
                NumberActivitiesActive++;
            }
        }
    
        public virtual void OnActivityStopped(Activity activity)
        {
            if (!ExcludedActivities.Contains(activity.LocalClassName))
            {
                NumberActivitiesActive--;
                if (NumberActivitiesActive == 0)
                {
                    AppLeftTime = DateTime.Now;
                    if (activity.IsFinishing)
                        ApplicationState = ApplicationState.NotRunning;
                    else
                        ApplicationState = ApplicationState.Background;
                }
            }
        }
    }
    
    public enum ApplicationState
    {
        Background,
        Foreground,
        NotRunning,
        Unknown
    }
