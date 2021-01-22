    Class MyBillClass
    {
	    private DateTime requestDate;
    	private int requestCount;
	    public MyBillClass()
        {
            /// ===== we naming "a" constructor ===== ///
            requestDate = DateTime.Now;
        }
        public MyBillClass(int inputCount) : this()
        {
            /// ===== we naming "b" constructor ===== ///
            /// ===== This method is "Chained Method" ===== ///
            this.requestCount= inputCount;
        }
    }
