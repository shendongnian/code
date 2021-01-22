    using System;
    using System.IO;
    using System.Web.UI;
    
    namespace WebApplication1
    {
    	public partial class _Default : System.Web.UI.Page
    	{
    		private string nameLast = "May";
    		private string nameFirst = "Lance";
    		private string nameMiddle = "R.";
    		private string nameTitle = "Mr.";
    		private string company = "CoreLogic";
    		private string department = "Development";
    		private string uRL = "http://www.lancemay.com";
    		private string title = "Application Developer Senior";
    		private string profession = "Developer";
    		private string telephone = "(123) 555-1212";
    		private string fax = "(321) 555-1212";
    		private string mobile = "(555) 555-1212";
    		private string email = "lancemay@gmail.com";
    		private string office = "Louisville";
    		private string addressTitle = "";
    		private string streetName = "123 Easy St.";
    		private string city = "Louisville";
    		private string region = "KY";
    		private string postCode = "40223";
    		private string country = "US";
    		protected void Page_Load(object sender, EventArgs e)
    		{
    			StringWriter stringWrite = new StringWriter();
    			System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
    			//vCard Begin
    			stringWrite.WriteLine("BEGIN:VCARD");
    			stringWrite.WriteLine("VERSION:2.1");
    			//Name
    			stringWrite.WriteLine("N:" + nameLast + ";" + nameFirst + ";" + nameMiddle + ";" + nameTitle);
    			//Full Name
    			stringWrite.WriteLine("FN:" + nameFirst + " " + nameMiddle + " " + nameLast);
    			//Organisation
    			stringWrite.WriteLine("ORG:" + company + ";" + department);
    			//URL
    			stringWrite.WriteLine("URL;WORK:" + uRL);
    			//Title
    			stringWrite.WriteLine("TITLE:" + title);
    			//Profession
    			stringWrite.WriteLine("ROLE:" + profession);
    			//Telephone
    			stringWrite.WriteLine("TEL;WORK;VOICE:" + telephone);
    			//Fax
    			stringWrite.WriteLine("TEL;WORK;FAX:" + fax);
    			//Mobile
    			stringWrite.WriteLine("TEL;CELL;VOICE:" + mobile);
    			//Email
    			stringWrite.WriteLine("EMAIL;PREF;INTERNET:" + email);
    			//Address
    			stringWrite.WriteLine("ADR;WORK;ENCODING=QUOTED-PRINTABLE:" + ";" + office + ";" + addressTitle + "=0D" + streetName + ";" + city + ";" + region + ";" + postCode + ";" + country);
    
    			stringWrite.WriteLine("END:VCARD");
    			Response.ContentType = "text/x-vcard";
    			Response.Write(stringWrite.ToString());
    			Response.AppendHeader("Hi", "PMTS");
    			Response.End();
    		}
        }
    }
