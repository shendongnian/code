    private void OPCode()
            {
                int.TryParse(Calculations.Text, out int i);
                if (i == 0)
                {
                    Calculations.Text = 1.ToString();
                }
            }
