               string[] line = { 
                                    "Data recorded on date : " + DateTime.Now, 
                                    "The parameters of this Test Sequence were set to :",
                                    "X =" + Xactual + ",Y =" + Yactual + ",Z =" + Zactual,
                                    "Key Orientation = " + Key_OrientationBox.Text,
                                };
                string separator = ",";
                fnresultfile.WriteLine(string.Join(separator,line));
                fnresultfile.Close();
