    /// <summary>
    /// Represents a HTML div in an Mvc View
    /// </summary>
    public class MvcDiv : IDisposable
    {
        private bool _disposed;
        private readonly ViewContext _viewContext;
        private readonly TextWriter _writer;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="MvcDiv"/> class.
        /// </summary>
        /// <param name="viewContext">The view context.</param>
        public MvcDiv(ViewContext viewContext) {
            if (viewContext == null) {
                throw new ArgumentNullException("viewContext");
            }
            _viewContext = viewContext;
            _writer = viewContext.Writer;
        }
    
        /// <summary>
        /// Performs application-defined tasks associated with 
        /// freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true /* disposing */);
            GC.SuppressFinalize(this);
        }
    
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both 
        /// managed and unmanaged resources; <c>false</c> 
        /// to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                _writer.Write("</div>");
            }
        }
    
        /// <summary>
        /// Ends the div.
        /// </summary>
        public void EndDiv()
        {
            Dispose(true);
        }
    }
    
    
    /// <summary>
    /// HtmlHelper Extension methods for building a div
    /// </summary>
    public static class DivExtensions
    {
        /// <summary>
        /// Begins the div.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns></returns>
        public static MvcDiv BeginDiv(this HtmlHelper htmlHelper)
        {
            // generates <div> ... </div>>
            return DivHelper(htmlHelper, null);
        }
    
        /// <summary>
        /// Begins the div.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static MvcDiv BeginDiv(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes)
        {
            // generates <div> ... </div>>
            return DivHelper(htmlHelper, htmlAttributes);
        }
    
        /// <summary>
        /// Ends the div.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        public static void EndDiv(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write("</div>");
        }
    
        /// <summary>
        /// Helps build a html div element
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        private static MvcDiv DivHelper(this HtmlHelper htmlHelper, IDictionary<string, object> htmlAttributes)
        {
            TagBuilder tagBuilder = new TagBuilder("div");
            tagBuilder.MergeAttributes(htmlAttributes);
    
            htmlHelper.ViewContext.Writer.Write(tagBuilder.ToString(TagRenderMode.StartTag));
            MvcDiv div = new MvcDiv(htmlHelper.ViewContext);
    
            return div;
        }
    }
