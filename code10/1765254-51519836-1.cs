    public async Task<string> Add()
    {
        //you can put whatever you want, in my project, it's string containing the message
        //your stuff
        var Result = Helper.Get(Configuration.Settings);
    }
    private AsyncCommand<string> _addCommand;
    public AsyncCommand<string> AddCommand
            {
                get
                {
                    if (_addCommand!= null)
                        return _addCommand;
    
                    _addCommand= AsyncCommand.Create(Add);
                    return _addCommand;
                }
            }
