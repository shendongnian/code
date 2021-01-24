    public dynamic MSG
        {
            get
            {
                string obj = HttpContext.Current.Session["MSG"].ToString();
                return string.IsNullOrEmpty(obj) ? null : JsonConvert.DeserializeObject(obj);
            }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
                HttpContext.Current.Session["MSG"] = JsonConvert.SerializeObject(value);
            }
        }
