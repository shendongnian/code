    /// <summary>
    /// Your PageBase class.
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        /// <summary>
        /// Initializes a new instance of the Page class.
        /// </summary>
        public Page()
        {
            this.Load += new EventHandler(this.Page_Load);
        }
        /// <summary>
        /// Your Page Load
        /// </summary>
        /// <param name="sender">sender as object</param>
        /// <param name="e">Event arguments</param>
        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            {
                 //handle the situation gracefully.
            }
        }
    }
