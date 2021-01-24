    public class ChangePasswordModel 
    {
         [DisplayFormat(ConvertEmptyStringToNull = false)]
         public string userName { get; set; }
         [DisplayFormat(ConvertEmptyStringToNull = false)]
         public string oldPassword { get; set; }
         [DisplayFormat(ConvertEmptyStringToNull = false)]
         public string newPassword { get; set; }
    }
