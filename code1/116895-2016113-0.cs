    public partial class Form2 : Form
    {
        private Boolean isBrowsable(PropertyInfo info)
        {
            return info.GetCustomAttributes(typeof(BrowsableAttribute), false).Length>-1;
        }
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Boolean showCheckBoxes)
        {
            InitializeComponent();
            _showCheckBoxes = true;
        }
        private Boolean _showCheckBoxes;
        private Object _reflection;
        private TableLayoutPanel _table =  new TableLayoutPanel{Dock=DockStyle.Fill, CellBorderStyle = TableLayoutPanelCellBorderStyle.Single};
        public Object SelectedObject
        {
            get
            {
                return _reflection;
            }
            set
            {
                //clear all controls from the table
                _table.Controls.Clear();
                foreach (var property in _reflection.GetType().GetProperties())
                {
                    if (isBrowsable(property))
                    {
                        if ((property.PropertyType == typeof(int)) || (property.PropertyType == typeof(string)))
                        {
                            var textField = new TextBox { Dock = DockStyle.Fill, AutoSize = true };
                            textField.DataBindings.Add("Text", _reflection, property.Name);
                            _table.Controls.Add(textField, 2, _table.RowCount += 1);
                            var propertyLabel = new Label
                            {
                                Text = property.Name,
                                Dock = DockStyle.Fill,
                                TextAlign = ContentAlignment.MiddleLeft
                            };
                            _table.Controls.Add(propertyLabel, 1, _table.RowCount);
                            if (_showCheckBoxes)
                            {
                                var checkBox = new CheckBox
                                                   {
                                                       AutoSize = true,
                                                       Name = property.Name,
                                                       Dock = DockStyle.Left,
                                                       CheckAlign = ContentAlignment.TopLeft
                                                   };
                                _table.Controls.Add(checkBox, 0, _table.RowCount);
                            }
                        }
                    }
                }
                //add one extra row to finish alignment
                var panel = new Panel { AutoSize = true };
                _table.Controls.Add(panel, 2, _table.RowCount += 1);
                _table.Controls.Add(panel, 1, _table.RowCount);
                if (_showCheckBoxes)
                {
                    _table.Controls.Add(panel, 0, _table.RowCount);
                }
                Controls.Add(_table);
                if (!Controls.Contains(_table))
                    Controls.Add(_table);
            }
        }
        public Boolean Execute(Object reflection)
        {
            SelectedObject = reflection;
            return ShowDialog() == DialogResult.OK;
        }
    }
