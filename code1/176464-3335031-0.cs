    public class ThemedImageButton : ImageButton
    {
        protected override OnPreRender(EventArgs e)
        {
            // See if theme specific version of this file exists.  If not, point it to          normal images dir.
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath("~/App_Variants/" + GetUserTheme().ToString() + "/images/" + i.ImageUrl)))
                {
                    i.ImageUrl = "~/App_Variants/" + GetUserTheme().ToString() + "/images/" + i.ImageUrl;
                }
                else
                {
                    i.ImageUrl = "~/images/" + i.ImageUrl;
                }   
        }
    }
