    static void Main(string[] args)
        {
            var projectDetails = MockProjectItems();
            Console.WriteLine("Before sortig:");
            foreach (var item in projectDetails)
            {
                Console.WriteLine(item.toString);
            }
            var myProjects = projectDetails.OrderBy(p => p.Status).Select(p => p.toString);
            Console.WriteLine("\n\nAfter sorting:");
            foreach (var item in myProjects)
            {
                Console.WriteLine(item);
            }
        }
