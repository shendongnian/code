    public class TeachersDomain : ITeachersDomain
    {
        public ILoggingService LoggingService { get; set; }
        public TeachersDomain(ILoggingService loggingService)
        {
            LoggingService = loggingService;
        }
    }
