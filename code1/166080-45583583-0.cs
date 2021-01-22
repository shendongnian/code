    static class Helper
        {
            public static void SwtichToBoldRegular(this TextBox c)
            {
                if (c.Font.Style!= FontStyle.Bold)
                    c.Font = new Font(c.Font, FontStyle.Bold);
                else
                    c.Font = new Font(c.Font, FontStyle.Regular);
            }
        }
