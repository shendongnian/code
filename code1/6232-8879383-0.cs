      Private Sub FillGroups()
        Try
            'Create Connection and SQLCommand here.
            Conn.Open()
            Dim dr As SqlDataReader = cm.ExecuteReader
            dgvGroups.Rows.Clear()
            Dim PreviousGroup As String = ""
            Dim l As New List(Of Groups)
            While dr.Read
                Dim g As New Groups
                g.RegionID = CheckInt(dr("cg_id"))
                g.RegionName = CheckString(dr("cg_name"))
                g.GroupID = CheckInt(dr("vg_id"))
                g.GroupName = CheckString(dr("vg_name"))
                l.Add(g)
            End While
            dr.Close()
            Conn.Close()
            For Each a In (From r In l Select r.RegionName, r.RegionID).Distinct
                Dim RegionID As Integer = a.RegionID 'Doing it this way avoids a warning
                dgvGroups.Rows.Add(New Object() {a.RegionID, a.RegionName})
                Dim c As DataGridViewComboBoxCell = CType(dgvGroups.Rows(dgvGroups.RowCount - 1).Cells(colGroup.Index), DataGridViewComboBoxCell)
                c.DataSource = (From g In l Where g.RegionID = RegionID Select g.GroupID, g.GroupName).ToArray
                c.DisplayMember = "GroupName"
                c.ValueMember = "GroupID"
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Class Groups
        Private _RegionID As Integer
        Public Property RegionID() As Integer
            Get
                Return _RegionID
            End Get
            Set(ByVal value As Integer)
                _RegionID = value
            End Set
        End Property
        Private _RegionName As String
        Public Property RegionName() As String
            Get
                Return _RegionName
            End Get
            Set(ByVal value As String)
                _RegionName = value
            End Set
        End Property
        Private _GroupName As String
        Public Property GroupName() As String
            Get
                Return _GroupName
            End Get
            Set(ByVal value As String)
                _GroupName = value
            End Set
        End Property
        Private _GroupID As Integer
        Public Property GroupID() As Integer
            Get            
                Return _GroupID
            End Get
            Set(ByVal value As Integer)
                _GroupID = value
            End Set
        End Property
    End Class
