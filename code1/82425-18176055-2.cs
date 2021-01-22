-
     public class MainViewModel
        {
            public virtual string MainTextBox { get; set; }
    
            public RelayCommand TestActionCommand
            {
                get { return new RelayCommand(TestAction); }
            }
    
            public void TestAction()
            {
                Trace.WriteLine(MainTextBox);
            }
        }
