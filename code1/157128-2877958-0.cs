    public class NotFoundModel
    {
        private string _contentName;
        private string _notFoundTitle;
        private string _apologiesMessage;
        private string _linkText;
        private string _action;
        private string _controller;
        // properties omitted for brevity;
        public NotFoundModel(string contentName, string notFoundTitle, string apologiesMessage,
            string linkText, string action, string controller)
        {
            this._contentName = contentName;
            this._notFoundTitle = notFoundTitle;
            this._apologiesMessage = apologiesMessage;
            this._linkText = linkText;
            this._action = action;
            this._controller = controller;
        }
        
        }
