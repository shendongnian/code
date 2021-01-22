    public static Excel.Workbook OpenBook(Excel.Application excelInstance, string fileName, bool readOnly, bool editable,
            bool updateLinks) {
            Excel.Workbook book = excelInstance.Workbooks.Open(
                fileName, updateLinks, readOnly,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, editable, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing);
            return book;
        }
    public static void ReleaseRCM(object o) {
            try {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            } catch {
            } finally {
                o = null;
            }
        }
