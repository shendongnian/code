    public static Expression<Func<UserEx, UserExDTO>> GetUserExDtOCompbinedExpression()
        {
    	//Translate() and To() methods do all the job
        return GetUserDTOConversionExpression().Translate()
           .To(userEx => userEx.User, userExDTO => userExDTO.UserModel, GetUserExDTOConversionExpression());
        }
