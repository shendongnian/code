You'll need to override the RenderContents method or make your own LoginName control. Something like this will do the trick:
    protected override void RenderContents(HtmlTextWriter writer)
    {
          if (string.IsNullOrEmpty(Profile.FullName))
                return;
          nameToDisplay = HttpUtility.HtmlEncode(Profile.FullName);
          string formatExpression = this.FormatString;
          if (formatExpression .Length == 0)
          {
                writer.Write(nameToDisplay);
          }
          else
          {
                try
                {
                      writer.Write(string.Format(CultureInfo.CurrentCulture, formatExpression, new object[1] { nameToDisplay });
                }
                catch (FormatException exception)
                {
                      throw new FormatException("Invalid FormatString", exception1);
                }
          }
    }
