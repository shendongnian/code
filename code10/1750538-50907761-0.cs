    public class HomeSection2ViewModel : : IValidatableObject
    {
        public HomeSection2ViewModel()
        {
            Details = new List<HomeSection2DetailViewModel>();
        }
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public bool Validate { get; set; }
        public List<HomeSection2DetailViewModel> Details { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
          if(Validate)
          {
              if(string.IsNullOrEmpty(Title)
              {
                   yield return
                        new ValidationResult(errorMessage: "required",
                            memberNames: new[] { "Title" });
              }
          }
        }
    }
