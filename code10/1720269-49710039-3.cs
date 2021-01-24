    public async Task<IActionResult> PurchaseSession(PurchaseSessionViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        await _userManager.AddToRoleAsync(user, "Active");
        await _signInManager.RefreshSignInAsync(user);
        
        // We need to store an ID because 'user' may be disposed
        var userId = user.Id;
    
        // This create an environment where your local 'userId' variable still
        // exists even after your 'PurchaseSession' method ends
        Action sessionExpired = async () => { 
            await Task.Delay(10000);
            var activeUser = _userManager.FindById(userId);
            await _userManager.RemoveFromRoleAsync(activeUser, "Active"); 
        };
        Task.Run(sessionExpired);
        return RedirectToAction(nameof(Index));
    }
