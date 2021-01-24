      namespace aspnetWeb
          {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                List<Student> list = new List<Student>();
    
                for(int i=1;i<=10;i++)
                list.Add(new Student { ID = 1, Count = 20 });
    
                GridView1.DataSource = list.AsQueryable();
                GridView1.DataBind();
            }
        }
    
        public class Student
        {
            public int ID { get; set; }
    
            public int Count { get; set; }
        }
     }
