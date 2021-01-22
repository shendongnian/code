    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Messaging;
    namespace MSMQGui
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private string queueName = @".\private$\MyFunWithMSMQ";
            private MessageQueue queue = null;
    
            public MainWindow()
            {
                InitializeComponent();
    
                if (!MessageQueue.Exists(queueName))
                    MessageQueue.Create(queueName,false);
                
    
               queue = new MessageQueue(queueName);
               queue.ReceiveCompleted += receiveCompleted;
    
            }
    
            private void btnAddMessage_Click(object sender, RoutedEventArgs e)
            {
                string message = txtMessage.Text;
                txtMessage.Text = String.Empty;
    
                queue.Send(message);
    
                MessageBox.Show("Message :" + message + " sent");
            }
    
            private void Populate(object sender, RoutedEventArgs e)
            {
                try
                {
                    queue.BeginReceive(TimeSpan.FromSeconds(1)) ;     
                }
                catch (MessageQueueException)
                {
                    MessageBox.Show("No message available");
                }
            }
    
            private void receiveCompleted(object source, ReceiveCompletedEventArgs e)
            {
                try
                {
                    var message=queue.EndReceive(e.AsyncResult);
    
                   
    
                    Action<string> addMessage= (string msg) => {
                         ListViewItem item = new ListViewItem();
                         item.Content = msg;
                         lsvMessages.Items.Add(item);
                    };
    
                    this.Dispatcher.Invoke(addMessage, message.Body as string);
                }
                catch (MessageQueueException)
                {
                    MessageBox.Show("No message available");
                }
            }
        }
    }
