    @{
        ViewBag.Title = "Index";
        var MyModel = this.ViewBag.Model as List<string>;
    }
    
    @for (int i = 0; i < MyModel.Count ; i++)
    {
        <label>@MyModel[i]</label>
    }
