            if (activationRequest == null)
            {
                throw new BusinessException(JsonResponse.CreateBusinessExceptionResponse(ErrorMessageConstants.UserActivationCodeNotRequested), "");
            }
            else if (activationRequest.CreationTime.AddMinutes(3) < DateTime.Now)
            {
                throw new BusinessException(JsonResponse.CreateBusinessExceptionResponse(ErrorMessageConstants.UserActivationCodeIsTimedOut), "");
            }
