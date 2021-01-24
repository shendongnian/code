    namespace ServiceInterface.Models
    {
    public class MyData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    public  class MyDataFather
    {
        public MyData MyData { get; set; }
    }
    }
