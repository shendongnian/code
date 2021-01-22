        /// <summary>
        /// Date Format
        /// </summary>
        public DateFormat DateFormat
        {
            get
            {
                if (ViewState["DateFormat"] == null || ViewState["DateFormat"].ToString().Trim() == String.Empty)
                {
                    return DateFormat.Date;  //Default
                }
                return (DateFormat)ViewState["DateFormat"];
            }
            set
            {
                ViewState["DateFormat"] = value;
            }
        }
