    using System;
    
    namespace ConsoleApp2
    {
        class Program
        {
    
            public class CustomerAdd1
            {
                public delegate void Done(object Sender, EventArgs e);
                public event Done ListUpdated;
    
                public void UpdateNewList()
                {
                    //adding items to a generic List<T>,code removed as not relevant to post
                    //and raising the event afterwards
    
                    if (ListUpdated != null)
                    {
                        ListUpdated(this, EventArgs.Empty);
                    }
                }
            }
    
            public class CustomerAdd
            {
                public void SaveToDisk()
                {
                    CustomerAdd1 cuss = new CustomerAdd1();
                    cuss.ListUpdated += new CustomerAdd1.Done(DisplayDetails);
                    cuss.UpdateNewList();
                }
                private void DisplayDetails(object Sender, EventArgs e)
                {
                    Console.WriteLine("Test");
                }
            }
    
            static void Main(string[] args)
            {
                var c = new CustomerAdd();
                c.SaveToDisk();
                Console.ReadLine();
            }
        }
    }
