    using System;
    using System.Reflection;
    using System.Windows.Forms;
    class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Form form = new Form();
            // this bar will control the splitter
            ScrollBar sb = new HScrollBar {
                Minimum = 10, Maximum = 200,
                Dock = DockStyle.Bottom
            };
            // the grid we want to control
            PropertyGrid grid = new PropertyGrid {
                SelectedObject = form, Dock = DockStyle.Fill
            };
            // add to the form
            form.Controls.Add(grid);
            form.Controls.Add(sb);
            // event to update the grid
            sb.ValueChanged += delegate {
                MoveSplitterTo(grid, sb.Value);
            };
            Application.Run(form);
        }
        static void MoveSplitterTo(PropertyGrid grid, int x) {
            // HEALTH WARNING: reflection can be brittle...
            FieldInfo field = typeof(PropertyGrid)
                .GetField("gridView",
                    BindingFlags.NonPublic | BindingFlags.Instance);
            field.FieldType
                .GetMethod("MoveSplitterTo", 
                    BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(field.GetValue(grid), new object[] { x });
        }
    }
