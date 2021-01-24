    using System;
        
    namespace ConsoleApp1
    {
        class Program
        {
       
            static void Main(string[] args)
            {
                CustomerReceive cr = new CustomerReceive();
                cr.SaveToDisk();
                
            }
        }
    
        public class CustomerAdd
        {
            public delegate void Done(object Sender, EventArgs e);
            public event Done ListUpdated;
    
            public void UpdateNewList()
            {
                //adding items to a generic List<T>,code removed as not relevant to post
                //and raising the event afterwards
    
                if (ListUpdated != null)
                {
                    ListUpdated.Invoke(this, EventArgs.Empty);
                }
            }
        }
    
        public class CustomerReceive
        {
            public void SaveToDisk()
            {
                CustomerAdd cuss = new CustomerAdd();
                cuss.ListUpdated += new CustomerAdd.Done(DisplayDetails);
                cuss.UpdateNewList();
            }
            private void DisplayDetails(object Sender, EventArgs e)
            {
                int k = 0;
            }
        }
    }
