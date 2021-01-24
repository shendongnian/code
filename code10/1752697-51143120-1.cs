     [LatestErrorHandler(typeof(ExceptionContext))]
    //[CustomLoggingAttirbute]
    [Produces("application/json")]
    [Route("api/Calendar")]
    public class CalendarController : Controller
    {
          ICalendarActivities calendarActivities;
        IHostingEnvironment IHostingEnvironment;
        string projectFolder = "";
        string fileRootPath = "";
        // private string projectRootFolder;
        public CalendarController(ICalendarActivities _calendarActivities)
        {
            calendarActivities = _calendarActivities;
        }
        [HttpGet]
        [Route("")]
        
        public IActionResult GetAllCalenderReportList()
        {
            try
            {
                var calendars = calendarActivities.GetCalendarActivities();
                var result = AutoMapper.Mapper.Map<IEnumerable<LiteCalendarViewModel>>(calendars);
                return Ok(result);
            }
            catch (Exception ex)
            {
                //string msginnerexandstacktrace = string.Format("{0}; inner ex: {1};  stack trace: {2}", ex.Message, ex.InnerException, ex.StackTrace);
                //ExceptionLoggingService.Instance.WriteLog(string.Format("from frmdelivery.conditionallyprint():{0}", msginnerexandstacktrace));
                return BadRequest(ex);
            }
        }
