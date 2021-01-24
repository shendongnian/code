    using System.ComponentModel.DataAnnotations;
    namespace Proyect.Model
    {
        public enum TYPE_IDENTITY: byte {
            [Display (Name = "Nit")] NIT,
            [Display (Name = " Identification Card ")] IC,
            [Display (Name = " Foreign Identification Card ")] FIC,
            [Display (Name = "Passaport")] PASSAPORT,
            [Display (Name = "Other")] OTHER = 9
        }
    }
