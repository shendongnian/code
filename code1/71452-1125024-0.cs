    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                AttachEventHandler(backgroundWorker1,
                      Type.GetType("WindowsFormsApplication1.EventHandlers"),
                      "RunWorkerCompleted");
                backgroundWorker1.RunWorkerAsync();
            }
    
            private void AttachEventHandler(BackgroundWorker bgw, Type targetType,
                string eventHandlerMethodName)
            {
                object targetInstance = Activator.CreateInstance(targetType);
                bgw.RunWorkerCompleted += 
                    (RunWorkerCompletedEventHandler)Delegate.CreateDelegate(
                        typeof(RunWorkerCompletedEventHandler), 
                        targetInstance, eventHandlerMethodName);
            }
    
        }
    
        public class EventHandlers
        {
            public void RunWorkerCompleted(object sender, 
                System.ComponentModel.RunWorkerCompletedEventArgs e)
            {
                // do something 
            }
        }
    }
