        private GridViewRow _footerRow;
        public override GridViewRow FooterRow
        {
            get
            {
                GridViewRow f = base.FooterRow;
                if (f != null)
                    return f;
                else
                    return _footerRow;
            }
        }
