     static bool IsValid(User user)
     {
        // if the user is not null and IsBot flag is true, return true
        if (user != null && user.IsBot)
           return true;
        
        // either the user is null or the IsBot flag is false here, hence check the following calls
        return !(user.GetClient() == null || user.GetClient().GetData() == null || user.GetClient().GetData().CurrentRoomId != _room.RoomId);
     }
