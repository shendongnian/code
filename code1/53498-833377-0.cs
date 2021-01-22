    using My.Utilities.Web;
    ...
    
    // Derive the form class from BaseForm instead of Page.
    public class WebForm1: BaseForm
    {
    ...
    private void Page_Load(object sender, System.EventArgs e)
    {
      // If we only want to load the page to generate the time
      // zone offset cookie, we do not need to do anything else.
      if (InitializeLocalTime())
        return;
    
      // Assume that txtStartDate is a TextBox control.
      if (IsPostback)
      {
         // To display a date-time value, convert it from GMT (UTC)
         // to local time.
         DateTime startDate = GetStartDateFromDB(...);
         txtStartDate.Text  = FormatLocalDate(startDate);
         ...
      }
      else
      {
         // To save a date-time value, convert it from local
         // time to GMT (UTC).
         DateTime tempDate  = DateTime.Parse(txtStartDate.Text);
         DateTime startDate = ConvertLocalTimeToUtc(tempDate);
         SaveStartDateInDB(startDate, ...);
         ...
      }
    }
    ...
    }
