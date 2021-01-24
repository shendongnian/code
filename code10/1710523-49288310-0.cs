        [Category("Behavior")]
        [Themeable(true)]
        [Bindable(BindableSupport.No)]
        public bool ShowFooterWhenEmpty
        {
            get
            {
                if (this.ViewState["ShowFooterWhenEmpty"] == null)
                {
                    this.ViewState["ShowFooterWhenEmpty"] = false;
                }
                return (bool)this.ViewState["ShowFooterWhenEmpty"];
            }
            set
            {
                this.ViewState["ShowFooterWhenEmpty"] = value;
            }
        }
