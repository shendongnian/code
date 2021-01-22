    protected void Page_Load(object sender, EventArgs e) {
         this.Culture = "sv-SE";
         var monthNames = System.Globalization.DateTimeFormatInfo.CurrentInfo.MonthNames.ToList();
         this.MonthRepeater.DataSource = from month in monthNames
                                    select new {
                                        Number = monthNames.IndexOf(month) + 1,
                                        Name = month
                                    };
         this.MonthRepeater.DataBind();
