    private static int GetButtonIndexFromButtonName(string buttonName)
    {
        var index = -1;
        int.TryParse(buttonName.Replace("button", string.Empty), out index);
        return index <= 150 ? index : -1;
    }
    //methodsignature
    {
        var tabletBtns = Controls.OfType<Button>()
              .Select(b => new
                {
                  Button = b,
                  Index = GetButtonIndexFromButtonName(b.Name)
                })
               .Where(c => c.Index > 0)
               .Select(c => c.Button)
               .ToList();
    }
