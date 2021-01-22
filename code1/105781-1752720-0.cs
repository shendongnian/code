            bool isNumeric = true;
            foreach (char c in "12345")
            {
                if (!Char.IsNumber(c))
                {
                    isNumeric = false;
                    break;
                }
            }
