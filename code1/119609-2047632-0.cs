    using System.Net.Mail;
    namespace InTouch.Controllers
    {
	
	public class YourApp.Controllers
	{
		public ActionResult Index()
		{
			return View();
		}
	
		[AcceptVerbs("POST")]
		public ActionResult Index(string fromname, string fromemail, string toname, string toemail)
	  {
      const string emailregex = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
      var result = false;
      ViewData["fromname"] = fromname;
      ViewData["fromemail"] = fromemail;
      ViewData["toname"] = toname;
      ViewData["toemail"] = toemail;
      if (string.IsNullOrEmpty(fromname)) ViewData.ModelState.AddModelError("name", "Please enter your name!");
      if (string.IsNullOrEmpty(fromemail)) ViewData.ModelState.AddModelError("email", "Please enter your e-mail!");
      if (!string.IsNullOrEmpty(fromemail) && !Regex.IsMatch(fromemail, emailregex)) ViewData.ModelState.AddModelError("email", "Please enter your e-mail!");
      if (string.IsNullOrEmpty(toname)) ViewData.ModelState.AddModelError("comments", "Please enter a message!");
      if (!string.IsNullOrEmpty(toemail) && !Regex.IsMatch(toemail, emailregex)) ViewData.ModelState.AddModelError("email", "Please enter a valid recipient e-mail!");
      if (!ViewData.ModelState.IsValid) return View();
      var message = new MailMessage(fromemail, toemail)
			{
				Subject = "You have been invited to MyNewApp by " + fromname + "!",
				Body = fromname + " wants to invite you. Click my link httpwwwblahblah to join them!"
			};
			SmtpClient smtp = new SmtpClient();
			try
			{
				smtp.Send(message);
				result = true;
			}
			catch { }			
      
      return View("Thankyou");
		}
		
	}
    }
