    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Threading;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Nothing();
            }
     
            async void Nothing()
            {
                byte[] bitmapArray = new byte[2046 * 2046 * 3];
    
                byte a = 30;
                int b = 80;
                var k = a * 2 + b;
                
                for(int j =0; j < 10; j++)
                { 
                    for (int i = 0; i < 12558348; i++)
                    {
                        bitmapArray[i] = (byte)(63 + j*10);
                    }
                    PixelFormat pf = PixelFormats.Bgr24;
                    BitmapSource bitmap = BitmapSource.Create(2046, 2046, 96, 96, pf, null, bitmapArray, 2046 * 3);
                    BaslerImage.Source = bitmap;
                    await Task.Delay(1000);
                }
            }
        }
    }
