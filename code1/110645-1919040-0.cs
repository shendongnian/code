    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Test
    {
       public partial class Form1 : Form
       {
          public Form1()
          {
             InitializeComponent();
    
             //if you debug this code then the objects is holding all controls on this form
             object objects = this;
    
             Dictionary<Control, string> allControls = GetIt(objects);
          }
    
          /// <summary>
          /// How to get all control names an .Text values if availible (included this form)???
          /// </summary>
          private Dictionary<Control, string> GetIt(object objects)
          {
              Dictionary<Control, string> found = new Dictionary<Control, string>();
              Queue<Control> controlQueue = new Queue<Control>();
              controlQueue.Enqueue(objects as Control);
    
              while (controlQueue.Count > 0)
              {
                  Control item = controlQueue.Dequeue();
                  foreach (Control ctrl in item.Controls)
                  {
                      controlQueue.Enqueue(ctrl);
                  }
                  found.Add(item, item.Text);
              }
    
              return found;
          }
       }
    }
