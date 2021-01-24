       static void Main(string[] args)
        {
            string strQuery = "select * from emp_booking where emp_booking_id in (select e.emp_booking_id from emp_booking e, emp_booking_file ef where ef.booking_date>=getdate() and e.emp_booking_id = ef.emp_booking_id)";
            SqlCommand cmd = new SqlCommand(strQuery);
            DataTable dt = GetData(cmd);
            Transpose(dt);
            foreach (DataRow r in dt)
            {
                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("<Unique filename for each booking ID>", FileMode.Create));
                document.Open();
                iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
                PdfPTable table = new PdfPTable(dt.Columns.Count);
                float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f };
                table.SetWidths(widths);
                table.WidthPercentage = 100;
                foreach (DataColumn c in dt.Columns)
                {
                    table.AddCell(new Phrase(c.ColumnName, font5));
                }
                table.AddCell(new Phrase(r[0].ToString(), font5));
                table.AddCell(new Phrase(r[1].ToString(), font5));
                table.AddCell(new Phrase(r[2].ToString(), font5));
                table.AddCell(new Phrase(r[3].ToString(), font5));
                table.AddCell(new Phrase(r[4].ToString(), font5));
                document.Add(table);
                document.Close();
                ZipFile.CreateFromDirectory(@"<parent directory of pdf>", @"M://BookingSheetUpload/Zip/<unique zip name>.zip");
            }
        }
