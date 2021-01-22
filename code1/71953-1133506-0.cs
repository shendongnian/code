     //
     this.ProtectWorkSheet(ws);
     //helper method
     private void ProtectWorkSheet(Excel.Worksheet workSheet)
            {
                //protect sheet
                workSheet.Protect("yourpassword", true, true, true, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
