    public async Task<IActionResult> PurchaseSession(PurchaseSessionViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        await _userManager.AddToRoleAsync(user, "Active");
        await _signInManager.RefreshSignInAsync(user);
    
        // This create an environment where your local 'user' variable still exists even after your 'PurchaseSession' method ends
        Action sessionExpired = async () => { 
            await Task.Delay(10000);
            await _userManager.RemoveFromRoleAsync(user, "Active"); 
        };
        Task.Run(sessionExpired);
        return RedirectToAction(nameof(Index));
    }
