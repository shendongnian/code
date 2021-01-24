    public class SaveXML
        {
            public static void SaveData(object obj, string filename)
            {
                XmlSerializer sr = new XmlSerializer(obj.GetType());
                TextWriter writer = new StreamWriter(filename);
                sr.Serialize(writer, obj);
                writer.Close();
            }
        }
    public class Information
        {
            private string txtdata1;
            private string txtdata2;
            private string txtdata3;
    
            public string PatientName
            {
                get { return txtdata1; }
                set { txtdata1 = value; }
            }
    
            public string PatientWeight
            {
                get { return txtdata2; }
                set { txtdata2 = value; }
            }
            public string PatientTFIWeight
            {
                get { return txtdata3; }
                set { txtdata3 = value; }
            }
        }
    private void Save_Click(object sender, RoutedEventArgs e)
            {
                try
                {
                    Information info = new Information();
                    info.PatientName = Patient.Text;
                    info.PatientWeight = Weight.Text;
                    info.PatientTFIWeight = TFIWeight.Text;
                    SaveXML.SaveData(info, Patient.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
