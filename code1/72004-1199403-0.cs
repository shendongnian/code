    public class TestPoco()
    {
        public int Id {get;set;}
        public String Name {get;set;}
        public bool IsNew { get { return Id == 0 } };
        public void Delete()
        {
            // Test is an SubSonic IActiveRecord Object
            Test.Destroy(Id);
        }
    }
    private void MyTask()
    {
        List<TestPoco> list =
              DB.Select("Id", "Name").From<Test>().ExecuteTypedList<TestPoco>();
       foreach (var item in list)
       {
           if (item.Name.Contains("acme"))
               item.Delete();
       }
    }
