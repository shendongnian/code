    Friend WithEvents panelForm1 As panelForm
    
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            Try
                '
                'panelForm1
                '
                Me.panelForm1 = New ValidZoneExtracurricularTasks.SyncForm
                Me.panelForm1.ClientSize = New System.Drawing.Size(673, 228)
                Me.panelForm1.Dock = System.Windows.Forms.DockStyle.Fill
                Me.panelForm1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
                Me.panelForm1.Location = New System.Drawing.Point(3, 3)
                Me.panelForm1.Name = "panelForm1"
                Me.panelForm1.Text = "panelForm1"
                Me.panelForm1.Visible = False
                Me.panelForm1.Dock = DockStyle.Fill
                Me.panelForm1.TopLevel = False
            
                Me.tpgSync.Controls.Add(Me.SyncForm1)
                Me.SyncForm1.Show()
            Catch ex As Exception
    
            End Try
        End Sub
