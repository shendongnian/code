    private DateTime _fechaInicioRelacion;
        
    [XmlElement("FEC_INICIO_REL")]
    public string FechaInicioRelacionString
    {
        get
            {
                return _fechaInicioRelacion.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        set { }
    }
    
    [XmlIgnore]
    public DateTime FechaInicioRelacion
    {
        get { return _fechaInicioRelacion; }
        set { _fechaInicioRelacion = value; }
    }
