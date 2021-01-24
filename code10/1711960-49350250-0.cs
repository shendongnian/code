    dynamic _myvalue;
        public MainWindow()
        {
            try
            {
              var myValue =
                    from el in keyValueList
                    select el.Value;
                _myvalue = myValue;
            }
            catch (Exception ex)
            {
            }
        }
