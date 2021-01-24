    public class CookieProvider
    {
        public const string OWINCOOKIE = "MYCOOKIE";
    }
    public partial class Startup
    {
        ...
        public void ConfigureAuth(IAppBuilder app)
        {
            ...
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                ...
                CookieName = CookieProvider.OWINCOOKIE,
        ...
