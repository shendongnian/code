    using System;
    
    [Serializable]  //the missing piece
    public class RegisterFormData
    {
        public string username { get; set; }
        public string pass1 { get; set; }
        public string pass2 { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
    }
