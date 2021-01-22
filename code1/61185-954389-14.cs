    using (Html.Tag("ul"))
    {
        this.Model.ForEach(item => using(Html.Tag("li")) Html.Write(item));
        using(Html.Tag("li")) Html.Write("new");
    }
