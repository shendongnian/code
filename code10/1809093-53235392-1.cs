    public async Task<IActionResult> CreateRole(ApplicationRoleModel model)
    {
        try
        {
            foreach (var item in model.RoleClaimList)
            {
                var roleExists = await _roleManager.RoleExistsAsync(item.Role.Name);
                if (roleExists) continue;
                var createRole = _roleManager.CreateAsync(item.Role);
                foreach (var claim in item.ClaimList)
                {
                    var c = new System.Security.Claims.Claim(claim.Type, claim.Value);
                    await _roleManager.AddClaimAsync(item.Role, c);
                }
            }
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
