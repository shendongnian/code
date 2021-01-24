    // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        //public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var expenses = await _context.Expenses.SingleOrDefaultAsync(m => m.Id == id);
            //if (expenses == null)
            //{
            //    return NotFound();
            //}
            //return View(expenses);
            ExpensesViewModel vmodel = new ExpensesViewModel();
            if (expenses == null)
            {
                return NotFound();
            }
            else
            {
                vmodel.Id = expenses.Id;
                vmodel.Expense_Code = expenses.Expense_Code;
                vmodel.Expense_Name = expenses.Expense_Name;
                vmodel.Category = expenses.Category;
            }
            return View(vmodel);
        }
