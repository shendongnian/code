        using System;
        using System.Windows;
        namespace WpfApplication1
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                public MainWindow()
                {
                    InitializeComponent();
                    Content = FooConverter.Convert(new Point(950, 500), new Point(850, 500));
                }
            }
            public static class FooConverter
            {
                public static string Convert(Point curIPJos, Point oppIJPos)
                {
                    var ij = " Insulated Joint";
                    var deltaX = oppIJPos.X - curIPJos.X;
                    var deltaY = oppIJPos.Y - curIPJos.Y;
                    var teta = Math.Atan2(deltaY, deltaX);
                    string result;
                    if (-Math.PI / 4 <= teta && teta <= Math.PI / 4)
                        result = "Left" + ij;
                    else if (Math.PI / 4 < teta && teta <= Math.PI * 3 / 4)
                        result = "Top" + ij;
                    else if (Math.PI * 3 / 4 < teta && teta <= Math.PI || -Math.PI <= teta && teta <= -Math.PI * 3 / 4)
                        result = "Right" + ij;
                    else
                        result = "Bottom" + ij;
                    return result;
                }
            }
        }
