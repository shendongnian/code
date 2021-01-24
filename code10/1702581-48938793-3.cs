    private void NumberChecker()
    {
        int num = null;
        if (Int32.TryParse(txtRank.Text, out num) {
            // if TryParse returns true, then we have a result in `num`.
            if (num >= 0 && num <= 50)
            {
                errorProvider1.SetError(txtRank, string.Empty);
                errorProvider1.Clear();
            }
            else // txtRank.Text is a number, but is not within the range
            {
                errorProvider1.SetError(txtRank, "Between 1 and 50 please!");
            }
        }
        else // txtRank.Text is not a number to begin with
        {
            errorProvider1.SetError(txtRank, "txtRank.Text is not a number!");
        }
    }
