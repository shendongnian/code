     private void Splitinthread()
        {
            int bufferlength = 2048;
            int pointer = 1;
            int offset = 0;
            int length = 0;
            byte[] buff = new byte[2048];
            FileStream fstwrite = new FileStream("D:\\TEST.wmv", FileMode.Create);
            FileStream fst2 = new FileStream("E:\\karthi.wmv", FileMode.Open);
            int Tot_Len = (int)fst2.Length;
            int Remain_Buff = 0;
            //Stream fst = File.OpenRead("E:\\karth.wmv");
            while (pointer != 0)
            {
                try
                {
                    fst2.Read(buff, 0, bufferlength);
                    fstwrite.Write(buff, 0, bufferlength);
                    offset += bufferlength;
                    Remain_Buff = Tot_Len - offset;
                    Fileprogress.Value = CalculateProgress(offset, Tot_Len);
                    if (Remain_Buff < bufferlength)
                    {
                        byte[] buff1 = new byte[Remain_Buff];
                        pointer = fst2.Read(buff1, 0, Remain_Buff);
                        fstwrite.Write(buff1, 0, pointer);
                        Fileprogress.Value = CalculateProgress(offset, Tot_Len);
                        fstwrite.Close();
                        fst2.Close();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            MessageBox.Show("Completed");
        }
