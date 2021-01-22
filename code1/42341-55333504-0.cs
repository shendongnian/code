            var httpException = ex as HttpException;
            if (httpException != null)
            {
                if (httpException.WebEventCode == System.Web.Management.WebEventCodes.RuntimeErrorPostTooLarge)
                {
                    // Request too large
                    
                    return;
                    
                }
            }
