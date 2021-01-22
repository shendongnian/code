    public static void OnlyValidInput ( int parameterName ) 
    {
         if( new int[]{0,1,2}.Contains(parameterName))
         {
            //... do Ok stuff
         }
         else throw new CustomException ( "invalid param should be 0 , 1 , 2" );
    }
