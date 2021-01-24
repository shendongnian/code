     static bool IsValid(User user)
     {
        var isValid = false;
        // if the user is not null and IsBot flag is true, return true
        if (user != null && user.IsBot)
            isValid = true;
        
        // either the user is null or the IsBot flag is false here, hence check the following calls
        
       isValid = user.GetClient() != null && user.GetClient().GetData() != null && user.GetClient().GetData().CurrentRoomId == _room.RoomId;
            return isValid;
     }
