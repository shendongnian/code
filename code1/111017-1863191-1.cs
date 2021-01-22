            DateTime convertedDate;
            string zero = "0";
            if (!DateTime.TryParse(zero, out convertedDate))
            {
                throw new InvalidCastException(string.Format(
                    "Attempted Invalid Cast of {0} to DateTime",zero));
            }
