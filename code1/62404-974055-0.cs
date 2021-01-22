    public string OnClick;
        protected void Button1_Click(object sender, EventArgs e)
        {
            MethodInfo methodInfo = this.Page.GetType().GetMethod(OnClick);
            methodInfo.Invoke(this.Page, new object[]{ sender, e });
        }
