    class MyClass
    {
        private Dictionary<string, string> data = new Dictionary<string, string>();
    
        public MyClass()
        {
            data.Add("Turing, Alan", "Alan Mathison Turing, OBE, FRS (pronounced /ˈtjʊ(ə)rɪŋ/) (23 June, 1912 – 7 June, 1954) was a British mathematician, logician, cryptanalyst and computer scientist.")
            //Courtesy of [Wikipedia][3]. Used without permission
        }
        public string this [string index]
        {
            get
            {
                return data[index];
            }
        }
    }
