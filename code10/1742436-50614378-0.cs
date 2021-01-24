        public static Application App;
        public static Workbook Wb;
        public static Worksheet Ws;
        public static object GetGetTimeElapsed(string Fecha_Inicio, string Fecha_Fin)
        {
            try
            {
                if (App == null)
                {
                    App = new Application();
                    Wb = App.Workbooks.Add();
                    Ws = (Worksheet)Wb.Worksheets.get_Item(1);
                }               
                Ws.Cells[1, 1].Formula = "=DATEDIF(\"" + Fecha_Inicio + "\",\"" + Fecha_Fin + "\",\"MD\")";
                Ws.Cells[1, 2].Formula = "=DATEDIF(\"" + Fecha_Inicio + "\",\"" + Fecha_Fin + "\",\"YM\")";
                Ws.Cells[1, 3].Formula = "=DATEDIF(\"" + Fecha_Inicio + "\",\"" + Fecha_Fin + "\",\"Y\")";
                double DaysElapsed = Ws.Cells[1, 1].Value;
                double MonthsElapsed = Ws.Cells[1, 2].Value;
                double YearsElapsed = Ws.Cells[1, 3].Value;
                var List = new
                {
                    Days = DaysElapsed,
                    Months = MonthsElapsed,
                    Years = YearsElapsed
                };
                return new { List.Days, List.Months, List.Years };
            }
            catch (Exception ex)
            {
                throw new BaseException(ex);
            }           
        }
