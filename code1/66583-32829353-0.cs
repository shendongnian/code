    namespace TestProject
    {
        public partial class Form1 :Form
        {
            public Form1()
            {
                InitializeComponent();
    
                List<string> FirstList = new List<string>();
                FirstList.Add("1234");
                FirstList.Add("4567");
    
                // In my code, I know I would not have this here but I put it in as a demonstration that it will not be in the secondList twice
                FirstList.Add("Three");  
    
                List<string> secondList = GetList(FirstList);            
                foreach (string item in secondList)
                    Console.WriteLine(item);
            }
    
            private List<String> GetList(List<string> SortBy)
            {
                List<string> list = new List<string>();
                list.Add("One");
                list.Add("Two");
                list.Add("Three");
    
                list = list.Union(SortBy).ToList();
                
                return list;
            }
        }
    }
