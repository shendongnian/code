    public class MeetingMinutesModel:PageModel
    {
        //[BindProperty] remove it
        public MeetingMinuteInputDto MeetingToCreate { get; set; }
        //[BindProperty] remove it
        public MeetingMinuteUpdateDto MeetingToUpdate { get; set; } 
        //...stuff
    }
    
        public IActionResult OnPost([Bind ("Name, FileToUpload, AdditionalInfo")] MeetingMinuteInputDto MeetingToCreate)
    {
        //Do somthing
    }
