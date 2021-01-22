    public TextTransformHelper(int maxColumns)
        {
            _maxColumns = maxColumns;
            if (_maxColumns == -1)
            {
                // try to determine console width
                string os = Environment.GetEnvironmentVariable("OS");
                if (os != null && os.StartsWith("Win"))
                {
                    ConsoleUtils.ConsoleHelper ch = new ConsoleUtils.ConsoleHelper();
                    _maxColumns = ch.GetScreenInfo().Size.X;
                    if(_maxColumns == 0) //added
                        _maxColumns = -1; //added
                }
            }
        }
