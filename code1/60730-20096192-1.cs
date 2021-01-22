    [Import(typeof(ILedPanel)]
    public ExportFactory<ILedPanel> PanelFactory { get; set; }
    public ILedPanel CreateNewLedPanelInstance()
    {
        return PanelFactory.CreateExport().Value;
    }
