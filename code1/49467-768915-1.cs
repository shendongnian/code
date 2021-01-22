    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CustomMessageBox
        Inherits System.Windows.Forms.Form
    
        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub
    
        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer
    
        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Me.msgBoxText = New System.Windows.Forms.Label
        Me.msgBoxIcon = New System.Windows.Forms.PictureBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.msgBoxButton1 = New System.Windows.Forms.Button
        Me.msgBoxButton3 = New System.Windows.Forms.Button
        Me.msgBoxButton2 = New System.Windows.Forms.Button
        CType(Me.msgBoxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'msgBoxText
        '
        Me.msgBoxText.AutoSize = True
        Me.msgBoxText.Cursor = System.Windows.Forms.Cursors.Cross
        Me.msgBoxText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.msgBoxText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.msgBoxText.Location = New System.Drawing.Point(59, 0)
        Me.msgBoxText.MaximumSize = New System.Drawing.Size(245, 0)
        Me.msgBoxText.Name = "msgBoxText"
        Me.msgBoxText.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.msgBoxText.Size = New System.Drawing.Size(39, 33)
        Me.msgBoxText.TabIndex = 6
        Me.msgBoxText.Text = "Label1"
        '
        'msgBoxIcon
        '
        Me.msgBoxIcon.Dock = System.Windows.Forms.DockStyle.Left
        Me.msgBoxIcon.Location = New System.Drawing.Point(0, 0)
        Me.msgBoxIcon.Name = "msgBoxIcon"
        Me.msgBoxIcon.Padding = New System.Windows.Forms.Padding(15, 10, 0, 0)
        Me.msgBoxIcon.Size = New System.Drawing.Size(59, 53)
        Me.msgBoxIcon.TabIndex = 4
        Me.msgBoxIcon.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.msgBoxButton1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.msgBoxButton3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.msgBoxButton2, 2, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 53)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 10)
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(305, 39)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'msgBoxButton1
        '
        Me.msgBoxButton1.AutoSize = True
        Me.msgBoxButton1.Location = New System.Drawing.Point(34, 3)
        Me.msgBoxButton1.Name = "msgBoxButton1"
        Me.msgBoxButton1.Size = New System.Drawing.Size(75, 23)
        Me.msgBoxButton1.TabIndex = 0
        Me.msgBoxButton1.Text = "Button1"
        Me.msgBoxButton1.UseVisualStyleBackColor = True
        '
        'msgBoxButton3
        '
        Me.msgBoxButton3.AutoSize = True
        Me.msgBoxButton3.Location = New System.Drawing.Point(196, 3)
        Me.msgBoxButton3.Name = "msgBoxButton3"
        Me.msgBoxButton3.Size = New System.Drawing.Size(75, 23)
        Me.msgBoxButton3.TabIndex = 2
        Me.msgBoxButton3.Text = "Button3"
        Me.msgBoxButton3.UseVisualStyleBackColor = True
        '
        'msgBoxButton2
        '
        Me.msgBoxButton2.AutoSize = True
        Me.msgBoxButton2.Location = New System.Drawing.Point(115, 3)
        Me.msgBoxButton2.Name = "msgBoxButton2"
        Me.msgBoxButton2.Size = New System.Drawing.Size(75, 23)
        Me.msgBoxButton2.TabIndex = 1
        Me.msgBoxButton2.Text = "Button2"
        Me.msgBoxButton2.UseVisualStyleBackColor = True
        '
        'CustomMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(305, 92)
        Me.Controls.Add(Me.msgBoxText)
        Me.Controls.Add(Me.msgBoxIcon)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CustomMessageBox"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MessageBox"
        Me.TopMost = True
        CType(Me.msgBoxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    
      End Sub
      Friend WithEvents msgBoxText As System.Windows.Forms.Label
      Friend WithEvents msgBoxIcon As System.Windows.Forms.PictureBox
      Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
      Friend WithEvents msgBoxButton1 As System.Windows.Forms.Button
      Friend WithEvents msgBoxButton3 As System.Windows.Forms.Button
      Friend WithEvents msgBoxButton2 As System.Windows.Forms.Button
    End Class
