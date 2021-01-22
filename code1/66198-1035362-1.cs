    using System.Drawing;
    using AwesomeCompany.ReallyAwesomeStuff.AwesomeLibrary.Drawing;
    /* AwesomeCompany.ReallyAwesomeStuff.AwesomeLibrary.Drawing has a StringFormat class */
    using AwesomeStringFormat = AwesomeCompany.ReallyAwesomeStuff.AwesomeLibrary.Drawing.Stringformat;
	using StringFormat = System.Drawing.StringFormat;
    public class AwesomeForm() : Form
	{
	    private AwesomeForm()
		{
			AwesomeStringFormat stringFormat = new AwesomeStringFormat();
			stringFormat.Color = Color.Red;
			/* etc */
		}
	}
