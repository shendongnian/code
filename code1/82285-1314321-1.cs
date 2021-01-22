    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Threading;
    namespace ThreadWithDataReturnExample
    {
        public partial class Form1 : Form
        {
            private Thread thread1 = null;
            
            public Form1()
            {
                InitializeComponent();
    
                thread1 = new Thread(new ThreadStart(this.threadEntryPoint));
                thread1_Thread1Completed += new AsyncCompletedEventHandler(thread1_Thread1Completed);
            }
    
            private void startButton_Click(object sender, EventArgs e)
            {
                thread1.Start();
                //Alternatively, you could pass some object
                //in such as Start(someObject);
                //With apprioriate locking, or protocol where
                //no other threads access the object until
                //an event signals when the thread is complete,
                //any other class with a reference to the object 
                //would be able to access that data.
                //But instead, I'm going to use AsyncCompletedEventArgs 
                //in an event that signals completion
            }
                   
            void thread1_Thread1Completed(object sender, AsyncCompletedEventArgs e)
            {
                if (this.InvokeRequired)
                {//marshal the call if we are not on the GUI thread                
                    BeginInvoke(new AsyncCompletedEventHandler(thread1_Thread1Completed),
                      new object[] { sender, e });
                }
                else
                {
                    //display error if error occurred
                    //if no error occurred, process data
                    if (e.Error == null)
                    {//then success
                       
                        MessageBox.Show("Worker thread completed successfully");
                        DataYouWantToReturn someData = e.UserState as DataYouWantToReturn;
                        MessageBox.Show("Your data my lord: " + someData.someProperty);
    
                    }
                    else//error
                    {
                        MessageBox.Show("The following error occurred:" + Environment.NewLine + e.Error.ToString());
                    }
                }
            }
    
            #region I would actually move all of this into it's own class
                private void threadEntryPoint()
                {
                    //do a bunch of stuff
    
                    //when you are done:
                    //initialize object with data that you want to return
                    DataYouWantToReturn dataYouWantToReturn = new DataYouWantToReturn();
                    dataYouWantToReturn.someProperty = "more data";
    
                    //signal completion by firing an event
                    OnThread1Completed(new AsyncCompletedEventArgs(null, false, dataYouWantToReturn));
                }
    
                /// <summary>
                /// Occurs when processing has finished or an error occurred.
                /// </summary>
                public event AsyncCompletedEventHandler Thread1Completed;
                protected virtual void OnThread1Completed(AsyncCompletedEventArgs e)
                {
                    //copy locally
                    AsyncCompletedEventHandler handler = Thread1Completed;
                    if (handler != null)
                    {
                        handler(this, e);
                    }
                }
            #endregion
    
        }
    }
