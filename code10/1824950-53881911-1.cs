    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
    using System.Drawing;
    using System.Collections.ObjectModel;
    using System.Text.RegularExpressions;
    
    namespace WpfApplication1
    {
        public class Item
        {
            public uint width;
            public uint starWidth;
            public uint starHeight;
    
            public string id;
            public string question;
            public PointCollection points;
            public SolidColorBrush fillColor;
            public SolidColorBrush strokeColor;
            public HorizontalAlignment horizontalAlignment;
            public VerticalAlignment verticalAlignment;
    
            public uint WIDTH
            {
                get { return width; }
                set { width = value; }
            }
            public uint STAR_WIDTH
            {
                get { return starWidth; }
                set { starWidth = value; }
            }
            public uint STAR_HEIGHT
            {
                get { return starHeight; }
                set { starHeight = value; }
            }
            public string SURVEY_ID
            {
                get { return id; }
                set { id = value; }
            }
            public string SURVEY_QUESTION
            {
                get { return question; }
                set { question = value; }
            }
            public PointCollection POINTS
            {
                get { return points; }
                set { points = value; }
            }
            public SolidColorBrush FILL_COLOR
            {
                get { return fillColor; }
                set { fillColor = value; }
            }
            public SolidColorBrush STROKE_COLOR
            {
                get { return strokeColor; }
                set { strokeColor = value; }
            }
            public HorizontalAlignment H_Alignment
            {
                get { return horizontalAlignment; }
                set { horizontalAlignment = value; }
            }
            public VerticalAlignment V_Alignment
            {
                get { return verticalAlignment; }
                set { verticalAlignment = value; }
            }
        }
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                listBoxQuestion.ItemsSource = createItems();
            }
    
            private List<Item> createItems()
            {
                List<Item> items = new List<Item>();
    
                items.Add(createItem("1)", "Question 1"));
                items.Add(createItem("2)", "Question 2"));
                items.Add(createItem("3)", "Question 3"));
    
                return items;
            }
            private Item createItem(string id, string question)
            {
                Item item = new Item();
    
                item.width = 800;
                item.starHeight = 50;
                item.starWidth = 50;
    
                item.horizontalAlignment = HorizontalAlignment.Left;
                item.verticalAlignment = VerticalAlignment.Center;            
    
                item.id = id;
                item.question = question;
                item.points = getPoints();
                item.fillColor = getFillColor("Transparent");
                item.strokeColor = getStrokeColor("Green");
    
                return item;
            }
           
            private PointCollection getPoints()
            {
                PointCollection myPointLeftCollection = new PointCollection();
                System.Drawing.PointF[] pts = new System.Drawing.PointF[5];
    
                double rx = 24 / 2;
                double ry = 24 / 2;
                double cx = 0 + rx;
                double cy = 0 + ry;
    
                // Start at the top.
                double theta = -Math.PI / 2;
                double dtheta = 4 * Math.PI / 5;
                for (int i = 0; i < 5; i++)
                {
                    pts[i] = new System.Drawing.PointF(
                        (float)(cx + rx * Math.Cos(theta)),
                        (float)(cy + ry * Math.Sin(theta)));
                    theta += dtheta;
                }
    
                System.Windows.Point Point1Feedback = new System.Windows.Point(pts[0].X, pts[0].Y);
                System.Windows.Point Point2Feedback = new System.Windows.Point(16, 8);
                System.Windows.Point Point3Feedback = new System.Windows.Point(pts[3].X, pts[3].Y);
                System.Windows.Point Point4Feedback = new System.Windows.Point(18, 14);
                System.Windows.Point Point5Feedback = new System.Windows.Point(pts[1].X, pts[1].Y);
                System.Windows.Point Point6Feedback = new System.Windows.Point(12, 18);
                System.Windows.Point Point7Feedback = new System.Windows.Point(pts[4].X, pts[4].Y);
                System.Windows.Point Point8Feedback = new System.Windows.Point(6, 14);
                System.Windows.Point Point9Feedback = new System.Windows.Point(pts[2].X, pts[2].Y);
                System.Windows.Point Point10Feedback = new System.Windows.Point(9, 8);
                
                myPointLeftCollection.Add(Point1Feedback);
                myPointLeftCollection.Add(Point2Feedback);
                myPointLeftCollection.Add(Point3Feedback);
                myPointLeftCollection.Add(Point4Feedback);
                myPointLeftCollection.Add(Point5Feedback);
                myPointLeftCollection.Add(Point6Feedback);
                myPointLeftCollection.Add(Point7Feedback);
                myPointLeftCollection.Add(Point8Feedback);
                myPointLeftCollection.Add(Point9Feedback);
                myPointLeftCollection.Add(Point10Feedback);
    
                return myPointLeftCollection;
            }
            private SolidColorBrush getFillColor(string themeColorInner)
            {
                return (SolidColorBrush)new BrushConverter().ConvertFromString(themeColorInner);
            }
            private SolidColorBrush getStrokeColor(string themeColorBorder)
            {
                return (SolidColorBrush)new BrushConverter().ConvertFromString(themeColorBorder);
            }
     
            private void clicked(object sender, RoutedEventArgs e)
            {
    
            }
        }
    }
