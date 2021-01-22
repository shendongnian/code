    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace SplitterDistanceTest
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
             splitContainer1.SplitterDistance = groupBox1.Width;
             splitContainer1.SplitterMoved += new SplitterEventHandler(splitContainer1_SplitterMoved);
          }
    
          void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
          {
             ResizeSplitterDistance();
          }
    
          private const int MAXIMUM_SIZE = 200;
    
          private void ResizeSplitterDistance()
          {    
             if (splitContainer1.SplitterDistance < groupBox1.Width)
             {
                splitContainer1.SplitterDistance = groupBox1.Width;
             }
             if (splitContainer1.SplitterDistance > MAXIMUM_SIZE)
             {
                splitContainer1.SplitterDistance = MAXIMUM_SIZE;
             }
    
             // You could also do max/min percentages.  Ive shown this below
             // but commented out
             /*int minimum_percent = 30;
             int minimum_size = (int)((minimum_percent / 100m) * (decimal)splitContainer1.Width);
             int maximum_percent = 50;
             int maximum_size = (int)((maximum_percent / 100m) * (decimal)splitContainer1.Width);
             if (splitContainer1.SplitterDistance < minimum_size)
             {
                splitContainer1.SplitterDistance = minimum_size;
             }
             if (splitContainer1.SplitterDistance > maximum_size)
             {
                splitContainer1.SplitterDistance = maximum_size;
             }*/
          }
       }
    }
