      public string GetFormattedPhoneNumber(string phone)
            {
                if (phone != null && phone.Trim().Length == 10)
                    return string.Format("({0}) {1}-{2}", phone.Substring(0, 3), phone.Substring(3, 3), phone.Substring(6, 4));
                    return phone;
            }
