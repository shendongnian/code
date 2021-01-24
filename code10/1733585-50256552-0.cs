    public IPrinterRepository GetRepository(string name)
    {
        if (!_PrinterTypes.TryGetValue(name, out var type))
            throw new KeyNotFoundException("Sevice not implemented or not supported any more!");
        return _serviceProvider.GetService(type);
    }
    static readonly Dictionary<string, Type> _PrinterTypes = new Dictionary<string, Type>
    {
        [PrinterCode.Epson] = typeof(EpsonRepository),
        [PrinterCode.HP] = typeof(HPRepository)
    };
