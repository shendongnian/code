    public IEnumerable<SelectListItem> TodosCampos
    {
        get
        {
            foreach (var campo in _todosCampos)
            {
                // assumed you have 'campo.IsDefault' which is boolean property 
                yield return new SelectListItem 
                { 
                    Text = campo.Nombre, 
                    Value = campo.Id.ToString(), 
                    Selected = campo.IsDefault // set default selected values
                };
            }
        }
    }  
