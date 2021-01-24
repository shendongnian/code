    public class PersonModel : PageModel {
       ILogger<PersonModel> Logger { get; set; }
        public PersonModel(ILogger<PersonModel> logger)
        {
            this.Logger = logger;
        }
    }
