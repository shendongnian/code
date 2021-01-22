    public partial class Form1 : Form
    {
        public Form1()
        {
             IList<Data> data = new List<Data>();
            data.Add(new Data() { ID = 1, ParentID = 0, SomeData = "Example" });
            data.Add(new Data() { ID = 2, ParentID = 1, SomeData = "Another Example" });
            data.Add(new Data() { ID = 3, ParentID = 2, SomeData = "Example three" });
            data.Add(new Data() { ID = 4, ParentID = 3, SomeData = "Last example" });
            IList<Data> results = new List<Data>();
            Int32 parentID = 2;
            while (parentID > -1)
            {
                results.Add(
                    data.Where(x => x.ParentID == parentID).Single()
                );
                parentID--;
            }
        }
    }
    public class Data
    {
        public Int32 ID { get; set; }
        public Int32 ParentID { get; set; }
        public String SomeData { get; set; }
    }
