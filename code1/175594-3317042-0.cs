    foreach (SelectPlaceCategoriesResult category in placeCategories)
    {
        HyperLink hypBack = new HyperLink();
    
        hypBack.NavigateUrl = string.Format("category/{0}.aspx", category.Titulo.Trim().ToLower());
        hypBack.Text = category.Nombre.Trim();
    
        Page.Controls.Add(hypBack);
    }
