        public class UserState
        {
            public int Id { get; set; }
    
            public Guid ActivationId { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public bool IsAdmin { get; set; }
            // Serialize    
            public override string ToString()
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(this);
                return result;
            }
    
            // Deserialize
            public static UserState FromString(string text)
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                return serializer.Deserialize<UserState>(text);
            }
        }
    }
