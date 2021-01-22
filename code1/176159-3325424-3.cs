    delegate int Summer(int[] arr);  // delegate
    class Program
    {
        public event Summer OnSum;   // event
        void DoSum()
        {
            int[] data = {1, 2, 3} ;              
            int sum = 0;
              
            if (OnSum != null)  
              sum = OnSum(data);   // execute it.
        }
    }
