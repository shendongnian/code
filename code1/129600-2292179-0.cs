    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    public class MyData
    {
        public DateTime A { get; set; }
        public DateTime B { get; set; }
        public DateTime C { get; set; }
        [TypeConverter(typeof(CustomDateTimeConverter))]
        public DateTime D { get; set; }
    }
    class CustomDateTimeConverter : DateTimeConverter
    {
        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return ((DateTime)value).ToString("dd-MM-yyyy HH:mm:ss");
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
    static class Program {
        [STAThread]
        static void Main()
        {
            DateTime when = DateTime.Now;
            var data = new BindingList<MyData>
            {
                new MyData { A = when, B = when, C = when }
            };
            using (var form = new Form())
            using (var grid = new DataGridView {
                AutoGenerateColumns = false,
                DataSource = data, Dock = DockStyle.Fill })
            {
                form.Controls.Add(grid);
                grid.Columns.Add(
                    new DataGridViewTextBoxColumn {
                        HeaderText = "Vanilla",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        DataPropertyName = "A",
                    });
                grid.Columns.Add(
                    new DataGridViewTextBoxColumn {
                        HeaderText = "Format",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        DataPropertyName = "B",
                        DefaultCellStyle = { Format = "dd/MM/yyyy HH:mm:ss" }
                    });
                grid.Columns.Add(
                    new DataGridViewTextBoxColumn {
                        HeaderText = "CellFormatting",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        DataPropertyName = "C",
                    });
                grid.CellFormatting += (sender, args) =>
                {
                    if (args.Value != null && args.ColumnIndex == 2
                        && args.DesiredType == typeof(string))
                    {
                        args.Value = ((DateTime)args.Value).ToString("dd MM yyyy HH:mm:ss");
                    }
                };
                grid.Columns.Add(
                    new DataGridViewTextBoxColumn {
                        HeaderText = "TypeConverter",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        DataPropertyName = "D",
                    });
                Application.Run(form);
            }
        }
    
    }
