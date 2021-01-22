    public class Tab : Panel {
        private Literal InnerHtmlLiteral { get; set; }
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)] // this is the significant attribute.
        public string InnerHtml {
            get { return InnerHtmlLiteral.Text; }
            set { InnerHtmlLiteral.Text = value; }
        }
        public Tab() {
            InnerHtmlLiteral = new Literal();
        }
        protected override void OnInit(EventArgs e) {
            base.OnInit(e);
            Controls.Add(InnerHtmlLiteral);
            InnerHtmlLiteral.ID = ID + "_InnerHtml";
        }
    }
