    public async Task<IActionResult> OnPostAsync()
        {
            var validateBankAccount = ModelState.GetFieldValidationState("BankAccount");
            if (validateBankAccount == 
        Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
            {
                return RedirectToPage();
            }
            _context.BankAccounts.Add(BankAccount);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
