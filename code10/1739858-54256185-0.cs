    AppDomain.CurrentDomain.FirstChanceException += (sender, e) => {
        if (e.Exception.TargetSite.DeclaringType.Assembly == Assembly.GetExecutingAssembly())
        {
            logger.ErrorFormat("Exception Thrown: {0}\n{1}", e.Exception.Message, e.Exception.StackTrace);
        }
    };
