        // Insert code to create basic pie chart
        // See my blog post entitled "Pie Charts in ASP.NET" for full source code
 
         // Set pie labels to be outside the pie chart
         this.Chart2.Series[0]["PieLabelStyle"] = "Outside";
 
         // Set border width so that labels are shown on the outside
         this.Chart2.Series[0].BorderWidth = 1;
         this.Chart2.Series[0].BorderColor = System.Drawing.Color.FromArgb(26, 59, 105);
 
         // Add a legend to the chart and dock it to the bottom-center
         this.Chart2.Legends.Add("Legend1");
         this.Chart2.Legends[0].Enabled = true;
         this.Chart2.Legends[0].Docking = Docking.Bottom;
         this.Chart2.Legends[0].Alignment = System.Drawing.StringAlignment.Center;
 
         // Set the legend to display pie chart values as percentages
         // Again, the P2 indicates a precision of 2 decimals
         this.Chart2.Series[0].LegendText = "#PERCENT{P2}";
 
         // By sorting the data points, they show up in proper ascending order in the legend
         this.Chart2.DataManipulator.Sort(PointSortOrder.Descending, Chart2.Series[0]);
     }
