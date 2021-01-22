        private float[,] DataArrayFromString(string strData)
        {
            long I;
            byte[] bData = new byte[(Strings.Len(strData) - 1) + 1];
            for (I = 1; I <= Strings.Len(strData); I += 1)
            {
                bData[(int) (I - 1)] = (byte) Strings.Asc(Strings.Mid(strData, (int) I, 1));
            }
            MemoryStream sM = new MemoryStream(bData);
            BinaryReader bR = new BinaryReader(sM);
            int Dim1 = bR.ReadInt32();
            int Dim2 = bR.ReadInt32();
            float[,] newData = new float[Dim1, Dim2];
            for (I = 0; I <= Dim2; I += 1)
            {
                for (long J = 0; J <= Dim1; J += 1)
                {
                    newData[(int) J, (int) I] = bR.ReadSingle();
                }
            }
            bR.Close();
            sM.Close();
            return newData;
        }
