    using System.IO;
    using System.Web.UI;
    /// <summary>
    /// Represents a custom HtmlTextWriter that displays no span tag.
    /// </summary>
    public class HtmlTextWriterNoSpan : HtmlTextWriter
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="textWriter">Text writer.</param>
        public HtmlTextWriterNoSpan(TextWriter textWriter)
            : base(textWriter)
        { }
        /// <summary>
        /// Determines whether the specified markup element will be rendered to the requesting page.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="key">Tag key.</param>
        /// <returns>True if the markup element should be rendered, false otherwise.</returns>
        protected override bool OnTagRender(string name, HtmlTextWriterTag key)
        {
            // Do not render <span> tags
            if (key == HtmlTextWriterTag.Span)
                return false;
            // Otherwise, call the base class (always true)
            return base.OnTagRender(name, key);
        }
    }
