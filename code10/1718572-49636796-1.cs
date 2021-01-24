    class MainWIndowViewModel
    {
        public ObservableCollection<RowVM> Rows { get; set; }
        = new ObservableCollection<RowVM>
        {
            new RowVM
            {
                Col1=new ButtonData{ Content="Button A" },  Col2=new ButtonData{ Content="Button B" }
            },
                        new RowVM
            {
                Col1=new ButtonData{ Content="Button C" },  Col2=new ButtonData{ Content="Button D" }
            },
                         new RowVM
            {
                Col1=new ButtonData{ Content="Button E" } 
            }
        };
    }
