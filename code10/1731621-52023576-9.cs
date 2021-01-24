     public static void Get_User(User user, FirebaseApp app)
        {
            FirebaseDatabase database = FirebaseDatabase.GetInstance(app);
            DatabaseReference reference = database.GetReference($"Users/{user.UserID}");
            reference.AddListenerForSingleValueEvent(new User_DataValue(user, app));
            //$"Trying to make call for user orders Users/{user.UserID}");
        }
    class User_DataValue : Java.Lang.Object, IValueEventListener
        {
            private User User;
            private FirebaseApp app;
            public UserOrderID_Init_DataValue(User user, FirebaseApp app)
            {
                this.User = user;
                this.app = app;
            }
            public void OnCancelled(DatabaseError error)
            {
                //$"Failed To Get User Orders {error.Message}");
            }
            public void OnDataChange(DataSnapshot snapshot)
            {
                //"Data received for user orders");
                var gson = new GsonBuilder().SetPrettyPrinting().Create();
                var json = gson.ToJson(snapshot.Value); // Gson extention method obj -> string
                Formatted_Output("Data received for user order json ", json);
                User user = JsonConvert.DeserializeObject<User>(json); //Newtonsoft.Json extention method string -> object
                
               //now the user is a fully populated object with very little work
            }
