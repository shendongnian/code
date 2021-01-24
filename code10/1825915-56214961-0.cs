    public async Task<IActionResult> OnPostDeleteAsync(int index)
    {
        if (!ModelState.IsValid)
       {
            return Page();
       }
       ModelState.Clear();
       MyContractPermission.BudgetAssignYears
           .Remove(MyContractPermission.BudgetAssignYears[index]);            
       YearList = new SelectList(SamfaEnums.Years);
       return Page();
    }
