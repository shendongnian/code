    public class TestBOViewModel
     {
     
        private TestBO _myBO;
        
        public TestBOViewModel(TestBO bo)
        {
            _myBO = bo;
        }
     
        [Header("NoDisp")]
        public int ID 
        {
            get { return _myBO.ID; }
            set { _myBO.ID = value; }
        }
    }
