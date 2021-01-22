    public class ColorScheme
    {
         [Required]
         [StringLength(6)]
         public string Color1 {get; set; }
         public void Validate()
         {
             var errors = DataAnnotationsValidationRunner.GetErrors(this);
             if(errors.Any())
                 throw new RulesException(errors);
         }
    }
