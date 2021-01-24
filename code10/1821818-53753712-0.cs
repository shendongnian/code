    class Brand
    {
        public string Name {get; set;}
        public Model[] Models {get; set;}
    }
    class Model
    {
        public string Name {get; set;}
    }
    
    // init your brand list, and model list for each brand
    private Brands[] _brands = .  . . 
    // init lists
    lstBrands.DisplayMemeber = "Name";
    lstBrands.ValueMemeber = "Name";
    lstBrands.DataSource = _brands;
    // then on lstBrands selected intex changed
    private void lstBrands_SelectedIndexChanged (sender, e)
    {
        if (lstBrands.SelectedIndex = -1)
        {
            lsltModels.DataSource = null;
            return;
        }
        var brand = (Brand)lstBrands.SelectedItem //<-- note - ITEM, not index
        lsltModels.DisplayMemeber = "Name";
        lsltModels.ValueMemeber = "Name";
        lsltModels.DataSource = brand.Models;
    }
