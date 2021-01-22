        public bool esvalida_la_hora(string thetime)
        {
            Regex checktime = new Regex("^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$");
            if (!checktime.IsMatch(thetime))
                return false;
            if (thetime.Trim().Length < 5)
                thetime = thetime = "0" + thetime;
            string hh = thetime.Substring(0, 2);
            string mm = thetime.Substring(3, 2);
            
            int hh_i, mm_i;
            if ((int.TryParse(hh, out hh_i)) && (int.TryParse(mm, out mm_i)))
            {
                if ((hh_i >= 0 && hh_i <= 23) && (mm_i >= 0 && mm_i <= 59))
                {
                    return true;
                }
            }
            return false;
        }
