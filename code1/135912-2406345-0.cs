    private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //For missing crystal reports assembly
            if ((e.Exception is System.IO.FileNotFoundException) && (e.Exception.Message.IndexOf("CrystalDecisions.CrystalReports.Engine") > -1))
                MessageBox.Show("Crystal Reports is required to use this feature", "Crystal Reports", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
           }
