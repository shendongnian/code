        public void Dispose()
        {
            if (MyCommand != null)
            {
                MyCommand.Dispose();
            }
            //... Similarly for MyDataAdapter,MyDataSet etc.
        }
