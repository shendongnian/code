    public partial class ThisAddIn
    {
        Office.CommandBarButton btn;
        MyDialog dlg;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            #region VSTO generated code
            this.Application = (Excel.Application)Microsoft.Office.Tools.Excel
              .ExcelLocale1033Proxy.Wrap(typeof(Excel.Application), 
              this.Application);
            #endregion
            dlg = new MyDialog();
            var m_toolbar = this.Application.CommandBars.Add("WpfAddIn",
                Office.MsoBarPosition.msoBarTop, false, true);
            btn = (Office.CommandBarButton)m_toolbar.Controls
                    .Add(Office.MsoControlType.msoControlButton, 
                    missing, missing, missing, true);
            btn.Style = Office.MsoButtonStyle.msoButtonIconAndCaption;
            btn.Caption = "Open WPF Dialog";
            btn.FaceId = 1958;
            btn.Visible = true;
            btn.Click += new Microsoft.Office.Core
                 ._CommandBarButtonEvents_ClickEventHandler(btn_Click);
            m_toolbar.Visible = true;
        }
        void btn_Click(Microsoft.Office.Core.CommandBarButton Ctrl, 
           ref bool CancelDefault)
        {
            dlg.ShowDialog();
        }
