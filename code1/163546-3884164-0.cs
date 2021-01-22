    protected override void OnLoad(EventArgs e)
    {
        this.Response.Clear();
        this.Response.Cache.SetNoStore();
        this.Response.Cache.SetExpires(DateTime.Now);
        this.Response.StatusCode = 200;
        try
        {
            var postId = this.Request.Form["id"];
            var value = this.Request.Form["value"];
            this.Response.Write(value);
            switch (postId)
            {
                case "id1":
                    // write 'value' to DB or whatever
                    break;
                case "id2":
                    // write 'value' to DB or whatever
                    break;
                default:
                    this.Response.StatusCode = 501; // Not Implemented
            }
            this.Response.End();
        }
    }
