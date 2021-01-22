        For Each c1 As Control In CrystalReportViewer1.Controls
            If c1.GetType Is GetType(CrystalDecisions.Windows.Forms.PageView) Then
                Dim pv As CrystalDecisions.Windows.Forms.PageView = c1
                For Each c2 As Control In pv.Controls
                    If c2.GetType Is GetType(TabControl) Then
                        Dim tc As TabControl = c2
                        tc.ItemSize = New Size(0, 1)
                        tc.SizeMode = TabSizeMode.Fixed
                    End If
                Next
            End If
        Next
