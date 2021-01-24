       public InputModel Input { get; set; }
        public class InputModel
        {
            [Required(ErrorMessage ="{0} не может быть пустым")]
            [EmailAddress(ErrorMessage ="Неверный формат {0}")]
            [Display(Name = "Email")]
            public string Email { get; set; }
    
            [Required(ErrorMessage = "Введите {0}")]
            [StringLength(5, ErrorMessage = "{0} должна быть из {1} символов", MinimumLength = 5)]
            [Display(Name = "Последовательность")]
            public string Sequence { get; set; }
            ...
        }
