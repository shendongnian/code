    foreach (var ciApplication in _context.CIApplications.AsNoTracking())
                        {
                            if ((await _authorizationService.AuthorizeAsync(User, ciApplication, "CIAuthoringManagement")).Succeeded)
                            {
                                
                                CIApplications.Add(ciApplication);
                            }
                        }
    return CIApplications;
