    int HH = 1;
    private void Set_Time()
    {
        switch (CurrBtn.Text)
        {
            case "+":
                // Condition Check (Increase HH))
                // Within a limit of 23
                while (HH < 23) { HH++; break; }
                break;
            case "-":
                // Condition Check (Decrease HH)
                // Decrease HH but don't allow it to be less than 0 
                while (HH >= 0) { HH-=1; break; }
                break;
        }
        // Set Hour Text into Label
        lbl_HH.Text = Convert.ToString(HH);
    }
