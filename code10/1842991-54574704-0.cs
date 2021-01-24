    public class C
    {
        public void M()
        {
            int x = 3;
            Action action = () => Console.WriteLine(x);
           // 'action' now points to method called something like "<M>b__0"
        }
    }
