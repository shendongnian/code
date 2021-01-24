     [AbpMvcAuthorize]
        [DisableAuditing]
    public class ProfileController : AbpController
        {
    
     public async Task<FileResult> GetProfilePicture()
            {
    
            var user = await _userManager.GetUserByIdAsync(AbpSession.GetUserId());
    
                if (user.ProfilePictureId == null)
    
                {
    
                    return GetDefaultProfilePicture();
    
                }
    
    
                return await GetProfilePictureById(user.ProfilePictureId.Value);
    
    }
    
            }
