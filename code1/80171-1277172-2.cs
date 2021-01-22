    using System;
    using System.Web.UI;
    public partial class TemplateViewerPage : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            // load your properties
            _subject = "test";
            _messageBody = "body";
            base.OnLoad(e);
        }
        // your property
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        private string _messageBody;
        public string MessageBody
        {
            get { return _messageBody; }
            set { _messageBody = value; }
        }
    }
