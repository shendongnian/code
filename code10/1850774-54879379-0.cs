            List<string> months = new List<string>
            {
                "March",
                "February",
                "January",
                "December",
                "November",
                "October",
                "September",
                "August",
                "July",
                "June",
                "May",
                "April",
                ""
            };
            
            var previousMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            var newMonths = months.Skip(months.IndexOf(previousMonth)+1).Reverse().ToArray();
            DropDownList2.DataSource = newMonths;
            DropDownList2.DataTextField = "M";
            DropDownList2.DataValueField = "I";
            DropDownList2.DataBind();
