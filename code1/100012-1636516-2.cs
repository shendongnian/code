    Option<UserEntity> result = GetUserById(...);
    if (result.IsNothing()) {
        // deal with it
    } else {
        UserEntity value = result.GetValue();
    }
