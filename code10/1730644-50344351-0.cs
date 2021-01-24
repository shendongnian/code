    using System.ComponentModel.DataAnnotations;
    namespace DL.SO.ModelState.Dto.Users
    {
        public class AccountModel
        {
            [Required]
            [MaxLength(14)]
            [Display(Name = "account number")]
            public string AccountNumber { get; set; }
        }
    }
