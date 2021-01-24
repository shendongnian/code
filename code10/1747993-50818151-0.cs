    /// <summary>
    /// Handle events related to browser requests.
    /// </summary>
    public class RequestHandler : DefaultRequestHandler
    {
        /// <summary>
        /// Called when the render process terminates unexpectedly.
        /// </summary>
        /// <param name="browserControl">The ChromiumWebBrowser control</param>
        /// <param name="browser">the browser object</param>
        /// <param name="status">indicates how the process terminated.</param>
        /// <remarks>
        /// Remember that <see cref="browserControl"/> is likely on a different thread so care should be used
        /// when accessing its properties.
        /// </remarks>
        public override void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
        {
            switch (status)
            {
                case CefTerminationStatus.AbnormalTermination:
                    Log.Error("Browser terminated abnormally.");
                    break;
                case CefTerminationStatus.ProcessWasKilled:
                    Log.Error("Browser was killed.");
                    break;
                case CefTerminationStatus.ProcessCrashed:
                    Log.Error("Browser crashed while.");
                    break;
                default:
                    Log.Error($"Browser terminated with unhandled status '{status}' while at address.");
                    break;
            }
            RenderProcessTerminated?.Invoke(browserControl, status);
        }
        /// <summary>
        /// Fires when the render process terminates unexpectedly.
        /// </summary>
        public event EventHandler<CefTerminationStatus> RenderProcessTerminated;
    }
