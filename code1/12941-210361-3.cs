    foreach (StepUser deleted in usersToDelete)
    {
        // Should use SingleOfDefault here if there should only be one
        // matching entry in each of NewUsers/OldUsers. The
        // code below matches your existing loop.
        StepUser oldUser = OldUsers.LastOrDefault(u => u.UserId == deleted.UserId);
        StepUser newUser = NewUsers.LastOrDefault(u => u.UserId == deleted.UserId);
        // Existing code here using oldUser and newUser
    }
