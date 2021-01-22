            DateTime dt;
            if (!DateTime.TryParse(texbox.Text, new  System.Globalization.CultureInfo("en-GB"), System.Globalization.DateTimeStyles.None, dt))
            {
                //text is not in the correct format
            }
