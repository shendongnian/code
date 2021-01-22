            if( passwordStrengthRegularExpression != null )
            { 
                passwordStrengthRegularExpression = passwordStrengthRegularExpression.Trim();
                if( passwordStrengthRegularExpression.Length != 0 ) 
                { 
                    try
                    { 
                        Regex regex = new Regex( passwordStrengthRegularExpression );
                    }
                    catch( ArgumentException e )
                    { 
                        throw new ProviderException( e.Message, e );
                    } 
                } 
            }
            else 
            {
                passwordStrengthRegularExpression = string.Empty;
            }
