    using System;
    using System.Collections.Generic;
    using System.Windows;
    namespace WpfApplication9
    {
        public partial class MainWindow : Window
        {
            List<System.IO.MemoryStream> MemoryStreamCollection = new List<System.IO.MemoryStream>();
            public MainWindow()
            {
                InitializeComponent();
            }
            private void ConsumeMemory_Click(object sender, RoutedEventArgs e)
            {
                for (int i = 0; i < 500; i++)
                {
                    MemoryStreamCollection.Add(new System.IO.MemoryStream(System.IO.File.ReadAllBytes(@"C:\temp\bpmn.png")));
                }
                MessageBox.Show("Done");
            }
            private void ReleaseMemory_Click(object sender, RoutedEventArgs e)
            {
                foreach (System.IO.MemoryStream memoryStream in MemoryStreamCollection)
                {
                    memoryStream.Dispose();
                }
                MemoryStreamCollection = null;
                MessageBox.Show("Done");
            }
            private void GarbageCollect_Click(object sender, RoutedEventArgs e)
            {
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
                MessageBox.Show("Done");
            }
        }
    }
