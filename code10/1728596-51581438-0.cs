    public static Expression<Func<UserEx, UserExDTO>> GetUserExDTOConversionExpression()
    {
        return userEx => new UserExDTO
        {
            MyProperty1 = userEx.MyProperty1
            //We removed other model declaration here.
        };
    }
