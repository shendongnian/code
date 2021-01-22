        private bool IsValidEmail(string email)
        {
            bool valid = false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                valid = true;
            }
            catch
            {
                valid = false;
                goto End_Func;
            }
            valid = false;
            int pos_at = email.IndexOf('@');
            char checker = Convert.ToChar(email.Substring(pos_at + 1, 1));
            var chars = "qwertyuiopasdfghjklzxcvbnm0123456789";
            foreach (char chr in chars)
            {
                if (checker == chr)
                {
                    valid = true;
                    break;
                }
            }
            if (valid == false)
            {
                goto End_Func;
            } 
            int pos_dot = email.IndexOf('.', pos_at + 1);
            if(pos_dot == -1)
            {
                valid = false;
                goto End_Func;
            }
            valid = false;
            try
            {
                checker = Convert.ToChar(email.Substring(pos_dot + 1, 1));
                foreach (char chr in chars)
                {
                    if (checker == chr)
                    {
                        valid = true;
                        break;
                    }
                }
            }
            catch
            {
                valid = false;
                goto End_Func;
            }
            Regex valid_checker = new Regex(@"^[a-zA-Z0-9_@.-]*$");
            valid = valid_checker.IsMatch(email);
            if (valid == false)
            {
                goto End_Func;
            }
            List<int> pos_list = new List<int> { };
            int pos = 0;
            while (email.IndexOf('_', pos) != -1)
            {
                pos_list.Add(email.IndexOf('_', pos));
                pos = email.IndexOf('_', pos) + 1;
            }
            pos = 0;
            while (email.IndexOf('.', pos) != -1)
            {
                pos_list.Add(email.IndexOf('.', pos));
                pos = email.IndexOf('.', pos) + 1;
            }
            pos = 0;
            while (email.IndexOf('-', pos) != -1)
            {
                pos_list.Add(email.IndexOf('-', pos));
                pos = email.IndexOf('-', pos) + 1;
            }
            int sp_cnt = pos_list.Count();
            pos_list.Sort();
            for (int i = 0; i < sp_cnt - 1; i++)
            {
                if (pos_list[i] + 1 == pos_list[i + 1])
                {
                    valid = false;
                    break;
                }
                if (pos_list[i]+1 == pos_at || pos_list[i]+1 == pos_dot)
                {
                    valid = false;
                    break;
                }
            }
            
            if(valid == false)
            {
                goto End_Func;
            }
            if (pos_list[sp_cnt - 1] == email.Length - 1 || pos_list[0] == 0)
            {
                valid = false;
            }
        End_Func:;
            return valid;
        }
