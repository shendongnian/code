    using System.Web.UI;
    using System.Web.UI.WebControls;
    /// <summary>
    /// Represents a custom checkbox web control.
    /// Prevents itself to be wrapped into a <span> tag when disabled.
    /// </summary>
    public class CustomCheckBox : CheckBox
    {
        /// <summary>
        /// Renders the control to the specified HTML writer.
        /// </summary>
        /// <param name="writer">The HtmlTextWriter object that receives the control content.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            // Use custom writer
            writer = new HtmlTextWriterNoSpan(writer);
            // Call base class
            base.Render(writer);
        }
    }
