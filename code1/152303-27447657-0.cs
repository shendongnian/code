    public partial class SignAs : Page
    {
        private const string LoginAttempts = "LoginAttempts";
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            HttpContext current = HttpContext.Current;
            if (current == null)
            {
                throw new InvalidOperationException();
            }
            if (GetUrlParameter<bool>("signAs"))
            {
                HandleSignAs(current, GetUrlParameter<string>("returnUrl"));
            }
        }
        // ...
        private static void HandleSignAs(HttpContext context, string returnUrl)
        {
            int attempts = 0;
            HttpCookie attemptsCookie = context.Request.Cookies[LoginAttempts];
            if (attemptsCookie == null || string.IsNullOrEmpty(attemptsCookie.Value))
            {
                attemptsCookie = new HttpCookie(LoginAttempts);
            }
            else
            {
                attempts = int.Parse(attemptsCookie.Value, CultureInfo.InvariantCulture);
            }
            if (!string.IsNullOrEmpty(context.Request.Headers["Authorization"]))
            {
                // Attempts are counted only if an authorization token is informed.
                attempts++;
            }
            if (attempts>1)
            {
                attemptsCookie.Value = string.Empty;
                context.Response.Cookies.Add(attemptsCookie);
                context.Response.Redirect(returnUrl, true);
            }
            else
            {
                attemptsCookie.Value = attempts.ToString(CultureInfo.InvariantCulture);
                context.Response.Cookies.Add(attemptsCookie);
                SendEndResponse(context, 401, "401 Unauthorized");
            }
        }
        private static void SendEndResponse(HttpContext context, int code, string description)
        {
            HttpResponse response = context.Response;
            context.Items["ResponseEnded"] = true;
            context.ClearError();
            response.StatusCode = code;
            response.Clear();
            response.StatusDescription = description;
            response.AppendHeader("Connection", "close");
            response.AddHeader("WWW-Authenticate", "Negotiate");
            response.AddHeader("WWW-Authenticate", "NTLM");
            response.End();
        }
    }
   
