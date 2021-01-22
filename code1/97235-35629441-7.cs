    class Program
    {
        static void Main(string[] args)
        {
            SomeServiceClass s= new SomeServiceClass(); 
            var employeesToCollect= new []{0,1,2,3};
            //IQueryable execution part
            var IQueryableList = s.GetEmployeeAndPersonDetailIQueryable(employeesToCollect).Where(i => i.Gender=="M");            
            foreach (var emp in IQueryableList)
            {
                System.Console.WriteLine("ID:{0}, EName:{1},Gender:{2}", emp.PersonId, emp.Person.FirstName, emp.Gender);
            }
            System.Console.WriteLine("IQueryable contain {0} row in result set", IQueryableList.Count());
            //IEnumerable execution part
            var IEnumerableList = s.GetEmployeeAndPersonDetailIEnumerable(employeesToCollect).Where(i => i.Gender == "M");
            foreach (var emp in IEnumerableList)
            {
               System.Console.WriteLine("ID:{0}, EName:{1},Gender:{2}", emp.PersonId, emp.Person.FirstName, emp.Gender);
            }
            System.Console.WriteLine("IEnumerable contain {0} row in result set", IEnumerableList.Count());
              
            Console.ReadKey();
        }
    }
	
