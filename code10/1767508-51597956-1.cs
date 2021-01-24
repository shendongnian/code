    namespace ConsoleApp1
    {
   
        public class Job
        {
        public int  Key { get; set; }
        public int value1 { get; set; }
        public int value2 { get; set; }
    }
    class Program
    {
        static DataTable getJobTabel(List<Job> jobs)
        {
            DataTable results = new DataTable();
            results.Columns.Add("JobKkey", typeof(int));
            results.Columns.Add("Value1", typeof(int));
            results.Columns.Add("Value2", typeof(int));
            
            foreach(Job item in jobs)
            {
                object[] r = { item.Key, item.value1, item.value2, false };
                results.Rows.Add(new object[] { item.Key, item.value1, item.value2});
            }
            return results;
        }
        static void Main(string[] args)
        {
            List<Job> myJobs = new List<Job>;//populate the myjobs list
            DataTable JobsToProcess = getJobTabel(myJobs);
            //create your connection and command objects then add JobsToProcess as a parameter
        }
    }
}
