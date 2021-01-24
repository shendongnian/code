    class MyClassRepository {
   
      public List<MyClass> MyClassList { get; set; }
      public int MaxSize { get; set; }
    
      public MyClassRepository() {
        MyClassList = new List<MyClass>();
        MaxSize = 1000;
      }
      
      public void MyClassListSize() {
        MessageBox.Show("MyClassList.Count: " + MyClassList.Count);
      }
    
      // other list manager methods....
    }
