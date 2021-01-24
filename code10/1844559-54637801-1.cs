        public class UserCred
        {
                public string Uname { get; set; }
                public string Pass { get; set; }
        }
        [HttpPost]
        public string CheckUser(UserCred model) 
        {
            string uname = model.Uname;
            string pword = model.Pass;
            
            /* Your Code
             *  
             */
         }
