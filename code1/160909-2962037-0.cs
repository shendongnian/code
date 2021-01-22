    private IDictionary dataLayerProperties; 
    private IDictionary<string, dynamic> translatedProperties = null;
    protected virtual IDictionary<string, dynamic> Properties
    {
        if(translatedProperties == null)
        {
            translatedProperties = TranslateDictionary(dataLayerProperties);		
        }  
        return translatedProperties;
    }
    public IDictionary<string, dynamic> TranslateDictionary(IDictionary values)
    {
        return values.Keys.Cast<string>().ToDictionary(key=>key, key => values[key] as dynamic);            
    }
    
