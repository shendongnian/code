    public ICollection<UsuarioModel> UsuarioModelSettings
    {
        get
        {
             var json = AppSettings.GetValueOrDefault(nameof(UsuarioModelSettings), string.Empty);
             if (string.IsNullOrEmpty(json))
                 return null;
             return JsonConvert.DeserializeObject(json);
        }
        set
        {
             var collection = JsonConvert.SerializeObject(value);
             AppSettings.AddOrUpdateValue(nameof(UsuarioModelSettings), collection);
        }
    }
