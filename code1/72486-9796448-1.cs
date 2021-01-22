    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim dt As New DataTable
            Dim dc As DataColumn
            dc = New DataColumn("Question", System.Type.GetType("System.String"))
            dt.Columns.Add(dc)
    
            dc = New DataColumn("Ans1", System.Type.GetType("System.String"))
            dt.Columns.Add(dc)
            dc = New DataColumn("Ans2", System.Type.GetType("System.String"))
            dt.Columns.Add(dc)
            dc = New DataColumn("Ans3", System.Type.GetType("System.String"))
            dt.Columns.Add(dc)
            dc = New DataColumn("Ans4", System.Type.GetType("System.String"))
            dt.Columns.Add(dc)
            dc = New DataColumn("AnsType", System.Type.GetType("System.String"))
            dt.Columns.Add(dc)
    
    
            Dim Dr As DataRow
            Dr = dt.NewRow
            Dr("Question") = "What is Your Name"
            Dr("Ans1") = "Ravi"
            Dr("Ans2") = "Mohan"
            Dr("Ans3") = "Sohan"
            Dr("Ans4") = "Gopal"
            Dr("AnsType") = "Multi"
            dt.Rows.Add(Dr)
    
            Dr = dt.NewRow
            Dr("Question") = "What is your father Name"
            Dr("Ans1") = "Ravi22"
            Dr("Ans2") = "Mohan2"
            Dr("Ans3") = "Sohan2"
            Dr("Ans4") = "Gopal2"
            Dr("AnsType") = "Multi"
            dt.Rows.Add(Dr)
            Panel1.GrowStyle = TableLayoutPanelGrowStyle.AddRows
            Panel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
            Panel1.BackColor = Color.Azure
            Panel1.RowStyles.Insert(0, New RowStyle(SizeType.Absolute, 50))
            Dim i As Integer = 0
    
            For Each dri As DataRow In dt.Rows
               
    
    
                Dim lab As New Label()
                lab.Text = dri("Question")
                lab.AutoSize = True
    
                Panel1.Controls.Add(lab, 0, i)
    
    
                Dim Ans1 As CheckBox
                Ans1 = New CheckBox()
                Ans1.Text = dri("Ans1")
                Panel1.Controls.Add(Ans1, 1, i)
    
                Dim Ans2 As RadioButton
                Ans2 = New RadioButton()
                Ans2.Text = dri("Ans2")
                Panel1.Controls.Add(Ans2, 2, i)
                i = i + 1
    
                'Panel1.Controls.Add(Pan)
            Next
