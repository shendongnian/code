     public async Task<IActionResult> OnPostApplyGuess(int itemId)
        {
            GameModel model = (GameModel) _sessionHelper.GetItem(this.ToString());
            MyProp1= model.MyProp1;
            MyProp2 = model.MyProp2 ;
            MyProp3= model.MyProp3;
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Page();
        }
