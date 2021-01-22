    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Data;
    using Microsoft.Windows.Controls;
    namespace WpfApplication2
    {
        public partial class MainWindow : Window
        {
        public List<List<object>> TheData { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            // Generate some random data
            Random r = new Random();
            
            TheData = new List<List<object>>
            {
                new List<object> { r.Next(100), r.Next(100), r.Next(100),r.Next(100) },
                new List<object> {  r.Next(100), r.Next(100), r.Next(100),r.Next(100) },
                new List<object> {  r.Next(100), r.Next(100), r.Next(100) },
                new List<object> {  r.Next(100), r.Next(100), r.Next(100),r.Next(100) },
                new List<object> {  r.Next(100), r.Next(100), r.Next(100),r.Next(100) },
                new List<object> {  r.Next(100), r.Next(100), r.Next(100),r.Next(100), r.Next(100) }
            };
            // Now bind data to the grid
            // We need at least one element
            if (TheData.Count > 0)
            {
                // Find the longest row so we create enough columns
                var max = TheData.Max(c => c.Count);
                for (var i = 0; i < max; i++)
                {
                    TheGrid.Columns.Add(
                        new DataGridTextColumn
                        {
                            Header = string.Format("Column: {0:00}", i),
                            Binding = new Binding(string.Format("[{0}]", i))
                        }
                        );
                }
            }
            TheGrid.ItemsSource = TheData;
        }
    }
