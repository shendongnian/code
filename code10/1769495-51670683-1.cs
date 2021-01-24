    if (!result.Succeeded)
    {
        // DuplicateUserName(...) requires the UserName itself so it can add it in the
        // Description. We don't care about that so just provide null.
        var duplicateUserNameCode = _errorDescriber.DuplicateUserName(null).Code;
        // Here's another option that's less flexible but removes the need for _errorDescriber.
        // var duplicateUserNameCode = nameof(IdentityErrorDescriber.DuplicateUserName); 
        if (result.Errors.Any(x => x.Code == duplicateUserNameCode))
        {
            // Your code for handling DuplicateUserName.
        }
    }
