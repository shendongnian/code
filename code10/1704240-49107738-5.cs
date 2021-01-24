    using Microsoft.VisualBasic.FileIO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Dynamic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    namespace WpfApplication1
    {
        public partial class Window2 : Window, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            List<myDynamicObject> _listOfRecords;
            public List<myDynamicObject> ListOfRecords
            {
                get
                {
                    return _listOfRecords;
                }
            }
            public Window2()
            {
                InitializeComponent();
                DataContext = this;
            }
            public void LoadData(string fileName)
            {
                _listOfRecords = new List<myDynamicObject>();
                myDynamicObject record;
                TextFieldParser textFieldParser = new TextFieldParser(fileName);
                textFieldParser.TextFieldType = FieldType.Delimited;
                textFieldParser.SetDelimiters(",");
                string[] headers = null;
                string[] dataTypes = null;
                string[] fields;
                int i = 0;
                while(!textFieldParser.EndOfData)
                {
                    fields = textFieldParser.ReadFields();
                    if (i == 0)
                    {
                        headers = fields;
                    }
                    else if (i == 1)
                    {
                        dataTypes = fields;
                    }
                    else
                    {
                        record = new myDynamicObject();
                        for (int j = 0; j < fields.Length; j++)
                        {
                            switch(dataTypes[j].ToLower())
                            {
                                case "string":
                                    record.SetMember(headers[j], fields[j]);
                                    break;
                                case "int32":
                                    Int32 data;
                                    if (Int32.TryParse(fields[j], out data))
                                    {
                                        record.SetMember(headers[j], data);
                                    }
                                    break;
                                default:
                                    record.SetMember(headers[j], fields[j]);
                                    break;
                            }
                        }
                        _listOfRecords.Add(record);
                    }
                    i += 1;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ListOfRecords"));
                DataGrid1.Columns.Clear();
                for (int j = 0; j < headers.Length; j++)
                {
                    DataGrid1.Columns.Add(new DataGridTextColumn()
                    {
                        Header = headers[j],
                        Binding = new Binding()
                        {
                            Path = new PropertyPath(headers[j]),
                            Mode = BindingMode.OneWay
                        }
                    });
                }
            }
            private void FileOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                LoadData((FileOption.SelectedItem as Run).Text);
            }
        }
        public class myDynamicObject : DynamicObject
        {
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                string name = binder.Name;
                return dictionary.TryGetValue(name, out result);
            }
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                dictionary[binder.Name] = value;
                return true;
            }
            public void SetMember(string propertyName, object value)
            {
                dictionary[propertyName] = value;
            }
        }
    }
